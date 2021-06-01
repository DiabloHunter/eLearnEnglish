using eLearnEnglish_ASP.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace eLearnEnglish_ASP.Components
{
    public class DownVideoViewComponent : ViewComponent
    {
        private readonly IVideoRepository _videoRepository;

        public DownVideoViewComponent(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(string difficulty, int count)
        {
            var videos = await _videoRepository.GetDownVideoAsync(difficulty, count);
            return View(videos);
        }
    }
}
