using eLearnEnglish_ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Repository
{
    public interface IVideoRepository
    {
        Task<int> AddNewVideo(VideoModel model);
        Task<List<VideoModel>> GetAllVideo();
        string GetAppName();
        Task<List<VideoModel>> GetTopVideoAsync(int count);
        Task<VideoModel> GetVideoById(int id);
        List<VideoModel> SearchVideo(string title);
        Task<List<VideoModel>> GetDownVideoAsync(string difficulty, int count);
        Task<int> EditVideo(VideoModel model);
        Task<List<VideoModel>> GetVideo();
    }
}