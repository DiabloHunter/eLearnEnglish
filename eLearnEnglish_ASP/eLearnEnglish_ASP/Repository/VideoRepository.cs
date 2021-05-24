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
    public class VideoRepository
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
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                VideoUrl = model.VideoUrl
            };


            await _context.Video.AddAsync(newVideo);
            await _context.SaveChangesAsync();

            return newVideo.Id;
        }

        public async Task<List<VideoModel>> GetAllVideo()
        {
            return await _context.Video
                  .Select(music => new VideoModel()
                  {
                      Description = music.Description,
                      Id = music.Id,
                      Title = music.Title,
                      CoverImageUrl = music.CoverImageUrl,
                      VideoUrl = music.VideoUrl

                  }).ToListAsync();
        }

        public async Task<List<VideoModel>> GetTopVideoAsync(int count)
        {
            return await _context.Video
                  .Select(music => new VideoModel()
                  {
                      Description = music.Description,
                      Id = music.Id,
                      Title = music.Title,
                      CoverImageUrl = music.CoverImageUrl,
                      VideoUrl = music.VideoUrl

                  }).Take(count).ToListAsync();
        }
        public async Task<VideoModel> GetVideoById(int id)
        {
            return await _context.Video.Where(x => x.Id == id)
                 .Select(music => new VideoModel()
                 {
                     Description = music.Description,
                     Id = music.Id,
                     Title = music.Title,
                     CoverImageUrl = music.CoverImageUrl,
                     VideoUrl = music.VideoUrl
                 }).FirstOrDefaultAsync();
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

