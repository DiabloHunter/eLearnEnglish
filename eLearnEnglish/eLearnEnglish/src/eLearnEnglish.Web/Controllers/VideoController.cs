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
    public class VideoController : Controller
    {


        private readonly IVideoService videoService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public VideoController(IVideoService videoService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.videoService = videoService;
            this.mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

   /*     [Route("~/all-video")]*/
        public async Task<IActionResult> GetAllVideo()
        {
            var video = (await this.videoService.GetAllVideo())
                .Select(mapper.Map<AllVideoViewModel>);

            return this.View(video);
        }
        [Route("~/video-details/{id:int:min(1)}", Name = "videoDetailsRoute")]
        public async Task<IActionResult> GetVideo(int id)
        {

            var video = await this.videoService.GetVideoById(id);


            return this.View(video);

        }


        public Task<ViewResult> AddNewVideo(bool isSuccess = false, int videoId = 5)
        {
            var model = new AllVideoViewModel();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.NewVideoId = videoId;
            return Task.FromResult(View(model));
        }
        [HttpPost]
        public async Task<IActionResult> AddNewVideo(AllVideoViewModel videoModel)
        {
            if (ModelState.IsValid)
            {
                if (videoModel.CoverPhoto != null)
                {
                    string folder = "images/video/";
                    videoModel.CoverImageUrl = await UploadImage(folder, videoModel.CoverPhoto);
                }


                int id = await videoService.AddNewVideo(videoModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewVideo), new { isSuccess = true, videoId = id });
                }
            }

            return View();
        }

        public async Task<IActionResult> DeleteVideo(int id)
        {
            await this.videoService.DeleteVideo(id);

            return RedirectToAction("GetAllVideo", "Video");
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
