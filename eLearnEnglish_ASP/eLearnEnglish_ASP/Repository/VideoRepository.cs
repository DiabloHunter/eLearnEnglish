using eLearnEnglish_ASP.Data;
using eLearnEnglish_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly ApplicationDbContext _context = null;
        private readonly IConfiguration _configuration;

        public VideoRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<int> AddNewVideo(VideoModel model)
        {
            var newVideo = new Video()
            {
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                Difficulty = model.Difficulty,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                VideoUrl = model.VideoUrl,
                
            };


            await _context.Video.AddAsync(newVideo);
            await _context.SaveChangesAsync();

            return newVideo.Id;
        }

        public async Task<List<VideoModel>> GetAllVideo()
        {
            return await _context.Video
                  .Select(video => new VideoModel()
                  {
                      Description = video.Description,
                      Id = video.Id,
                      Title = video.Title,
                      Difficulty = video.Difficulty,
                      CoverImageUrl = video.CoverImageUrl,
                      VideoUrl = video.VideoUrl

                  }).ToListAsync();
        }

        public async Task<List<VideoModel>> GetTopVideoAsync(int count)
        {
            return await _context.Video
                  .Select(video => new VideoModel()
                  {
                      Description = video.Description,
                      Id = video.Id,
                      Title = video.Title,
                      Difficulty = video.Difficulty,
                      CoverImageUrl = video.CoverImageUrl,
                      VideoUrl = video.VideoUrl

                  }).Take(count).ToListAsync();
        }
        int VideoId;
        public async Task<VideoModel> GetVideoById(int id)
        {
            VideoId = id;
            return await _context.Video.Where(x => x.Id == id)
                 .Select(video => new VideoModel()
                 {
                     Description = video.Description,
                     Id = video.Id,
                     Title = video.Title,
                     Difficulty = video.Difficulty,
                     CoverImageUrl = video.CoverImageUrl,
                     VideoUrl = video.VideoUrl
                 }).FirstOrDefaultAsync();
        }

        public async Task<List<VideoModel>> GetDownVideoAsync(string difficulty, int count)
        {
            return await _context.Video.Where(x => x.Difficulty == difficulty && x.Id != VideoId)
                  .Select(video => new VideoModel()
                  {
                      Description = video.Description,
                      Id = video.Id,
                      Title = video.Title,
                      Difficulty = video.Difficulty,
                      CoverImageUrl = video.CoverImageUrl,
                      VideoUrl = video.VideoUrl

                  }).Take(count).ToListAsync();
        }


        public List<VideoModel> SearchVideo(string title)
        {
            return null;
        }
        public string GetAppName()
        {
            return _configuration["AppName"];
        }
    }
}

