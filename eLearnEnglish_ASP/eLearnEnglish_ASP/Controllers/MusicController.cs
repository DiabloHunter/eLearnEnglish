using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eLearnEnglish_ASP.Data;
using eLearnEnglish_ASP.Models;
using eLearnEnglish_ASP.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace eLearnEnglish_ASP.Controllers
{
    public class MusicController : Controller
    {
        private readonly IMusicRepository _musicRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public MusicController(IMusicRepository musicRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _musicRepository = musicRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("~/all-music")]
        public async Task<ViewResult> GetAllMusic()
        {
            var data = await _musicRepository.GetAllMusic();
            return View(data);
        }
        [Route("~/music-datails/{id:int:min(1)}", Name = "musicDetailsRoute")]
        public async Task<ViewResult> GetMusic(int id)
        {

            var data = await _musicRepository.GetMusicById(id);

            return View(data);
        }

        public List<MusicModel> SearchMusic(string musicName, string authorName)
        {
            return _musicRepository.SearchMusic(musicName, authorName);
        }
        [Authorize]
        public async Task<ViewResult> AddNewMusic(bool isSuccess = false, int musicId = 0)
        {
            var model = new MusicModel();

            //замена на уровне view
            /*ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id","Name");*/

            ViewBag.IsSuccess = isSuccess;
            ViewBag.MusicId = musicId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewMusic(MusicModel musicModel)
        {
            if (ModelState.IsValid)
            {
                if (musicModel.CoverPhoto != null)
                {
                    string folder = "images/music/";
                    musicModel.CoverImageUrl = await UploadImage(folder, musicModel.CoverPhoto);
                }


                int id = await _musicRepository.AddNewMusic(musicModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewMusic), new { isSuccess = true, musicId = id });
                }
            }

            //замена на уровне view
            /* ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");*/

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

    }
}
