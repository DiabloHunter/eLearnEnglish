using Quizaldo.Common.ViewModels;
using Quizaldo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quizaldo.Services.Interfaces
{
    public interface IMusicService
    {
        Task<IEnumerable<Music>> GetAllMusic();
        Task<IEnumerable<AllMusicViewModel>> GetMusic();
        Task<AllMusicViewModel> GetMusicById(int id);
        Task<List<AllMusicViewModel>> GetDownMusicAsync(string difficulty, int count);

        Task<int> AddNewMusic(AllMusicViewModel model);
        Task<List<AllMusicViewModel>> GetTopMusicAsync(int count);
        Task DeleteMusic(int id);

    }
}
