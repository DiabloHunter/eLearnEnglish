using Microsoft.AspNetCore.Mvc;
using Quizaldo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quizaldo.Web.Components
{
    public class DownMusicViewComponent : ViewComponent
    {
        private readonly IMusicService _musicRepository;

        public DownMusicViewComponent(IMusicService musicRepository)
        {
            _musicRepository = musicRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(string difficulty, int count)
        {
            if (difficulty != "")
            {
                var videos = await _musicRepository.GetDownMusicAsync(difficulty, count);
                return View(videos);
            }
            else
            {
                var videos = await _musicRepository.GetTopMusicAsync(count);
                return View(videos);
            }
        }
       
    }
}
