using Quizaldo.Common.ViewModels;
using Quizaldo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quizaldo.Services.Interfaces
{
    public interface IVideoService
    {
        Task<IEnumerable<Video>> GetAllVideo();
        Task<IEnumerable<AllVideoViewModel>> GetVideo();
        Task<AllVideoViewModel> GetVideoById(int id);
        Task<IEnumerable<AllVideoViewModel>> GetDownVideoAsync(string difficulty, int count);
        Task<List<AllVideoViewModel>> GetTopVideoAsync(int count);
        Task<int> AddNewVideo(AllVideoViewModel model);
        Task DeleteVideo(int id);


    }
}
