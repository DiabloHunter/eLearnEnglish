using Microsoft.AspNetCore.Mvc;
using Quizaldo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizaldo.Web.Components
{
    public class DownVideoViewComponent : ViewComponent
    {
        private readonly IVideoService _videoService;

        public DownVideoViewComponent(IVideoService videoService)
        {
            _videoService = videoService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string difficulty, int count)
        {
            if (difficulty != "")
            {
                var videos = await _videoService.GetDownVideoAsync(difficulty, count);
                return View(videos);

            }
            else
            {
                var videos = await _videoService.GetTopVideoAsync(count);
                return View(videos);
            }

        }
     
    }
}
