using eLearnEnglish_ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Repository
{
    public interface IMusicRepository
    {
        Task<int> AddNewMusic(MusicModel model);
        Task<List<MusicModel>> GetAllMusic();
        string GetAppName();
        Task<MusicModel> GetMusicById(int id);
        Task<List<MusicModel>> GetTopMusicAsync(int count);
        List<MusicModel> SearchMusic(string title, string author);
        Task<List<MusicModel>> GetDownMusicAsync(string difficulty);
    }
}