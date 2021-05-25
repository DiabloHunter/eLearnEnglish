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
    public class VideoController : Controller
    {
        private readonly IVideoRepository _videoRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public VideoController(IVideoRepository videoRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _videoRepository = videoRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("~/all-video")]
        public async Task<ViewResult> GetAllVideo()
        {
            var data = await _videoRepository.GetAllVideo();
            return View(data);
        }
        [Route("~/video-datails/{id:int:min(1)}", Name = "videoDetailsRoute")]
        public async Task<ViewResult> GetVideo(int id)
        {

            var data = await _videoRepository.GetVideoById(id);

            return View(data);
        }

        public List<VideoModel> SearchVideo(string title)
        {
            return _videoRepository.SearchVideo(title);
        }
        [Authorize]
        public async Task<ViewResult> AddNewVideo(bool isSuccess = false, int videoId = 0)
        {
            var model = new VideoModel();

            //замена на уровне view
            /*ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id","Name");*/

            ViewBag.IsSuccess = isSuccess;
            ViewBag.VideoId = videoId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewVideo(VideoModel videoModel)
        {
            if (ModelState.IsValid)
            {
                if (videoModel.CoverPhoto != null)
                {
                    string folder = "video/cover/";
                    videoModel.CoverImageUrl = await UploadImage(folder, videoModel.CoverPhoto);
                }


                int id = await _videoRepository.AddNewVideo(videoModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewVideo), new { isSuccess = true, videoId = id });
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
