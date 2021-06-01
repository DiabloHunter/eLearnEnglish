using eLearnEnglish_ASP.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Components
{
    public class DownMusicViewComponent : ViewComponent
    {
        private readonly IMusicRepository _videoRepository;

        public DownMusicViewComponent(IMusicRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(string difficulty, int count)
        {
            var videos = await _videoRepository.GetDownMusicAsync(difficulty, count);
            return View(videos);
        }
    }
}
