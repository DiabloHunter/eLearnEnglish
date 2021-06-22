using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Quizaldo.Models;
using Quizaldo.Services.Interfaces;
using Quizaldo.Data;
using AutoMapper;
using Quizaldo.Common.ViewModels;
using Quizaldo.Services.Implementations;

namespace Quizaldo.Web.Controllers
{
    public class MusicController : Controller
    {

        private readonly IMusicService musicService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public MusicController(IMusicService musicService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.musicService = musicService;
            this.mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }



        public async Task<IActionResult> GetAllMusic()
        {
            var music = (await this.musicService.GetAllMusic())
                .Select(mapper.Map<AllMusicViewModel>);

            return this.View(music);
        }
        [Route("~/music-details/{id:int:min(1)}", Name = "musicDetailsRoute")]
        public async Task<IActionResult> GetMusic(int id)
        {

            var music = await this.musicService.GetMusicById(id);


            return this.View(music);

        }


        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public async Task<ViewResult> AddNewMusic(bool isSuccess = false, int musicId = 0)
        {
            var model = new AllMusicViewModel();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.NewMusicId = musicId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewMusic(AllMusicViewModel musicModel)
        {
            if (ModelState.IsValid)
            {
                if (musicModel.CoverPhoto != null)
                {
                    string folder = "images/music/";
                    musicModel.CoverImageUrl = await UploadImage(folder, musicModel.CoverPhoto);
                }


                int id = await musicService.AddNewMusic(musicModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewMusic), new { isSuccess = true, musicId = id });
                }
            }

            return View();
        }
        public async Task<IActionResult> DeleteMusic(int id)
        {
            await this.musicService.DeleteMusic(id);

            return RedirectToAction("GetAllMusic", "Music");
        }
    }
}
