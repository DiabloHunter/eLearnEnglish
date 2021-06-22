using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Quizaldo.Common.ViewModels;
using Quizaldo.Data;
using Quizaldo.Models;
using Quizaldo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizaldo.Services.Implementations
{
    public class VideoService : DataService, IVideoService
    {

        public VideoService(QuizaldoDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Video>> GetAllVideo()
        {
            return await this.context.Video
                .ToListAsync();
        }


        public async Task<IEnumerable<AllVideoViewModel>> GetVideo()
        {
            return await this.context.Video.Select(x => new AllVideoViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();
        }



        int VideoId;
        public async Task<AllVideoViewModel> GetVideoById(int id)
        {
            VideoId = id;
            return await this.context.Video.Where(x => x.Id == id)
                 .Select(video => new AllVideoViewModel()
                 {
                     Description = video.Description,
                     Id = video.Id,
                     Title = video.Title,
                     Difficulty = video.Difficulty,
                     CoverImageUrl = video.CoverImageUrl,
                     VideoUrl = video.VideoUrl
                 }).FirstOrDefaultAsync();
        }
        public async Task DeleteVideo(int id)
        {
            var video = await this.context.Video.FirstOrDefaultAsync(j => j.Id == id);

            if (video == null)
            {
                return;
            }

            this.context.Video.Remove(video);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllVideoViewModel>> GetDownVideoAsync(string difficulty, int count)
        {
            return await this.context.Video.Where(x => x.Difficulty == difficulty && x.Id != VideoId)
                  .Select(video => new AllVideoViewModel()
                  {
                      Description = video.Description,
                      Id = video.Id,
                      Title = video.Title,
                      Difficulty = video.Difficulty,
                      CoverImageUrl = video.CoverImageUrl,
                      VideoUrl = video.VideoUrl

                  }).Take(count).ToListAsync();
        }


        public async Task<List<AllVideoViewModel>> GetTopVideoAsync(int count)
        {
            return await this.context.Video
                  .Select(video => new AllVideoViewModel()
                  {
                      Description = video.Description,
                      Id = video.Id,
                      Title = video.Title,
                      Difficulty = video.Difficulty,
                      CoverImageUrl = video.CoverImageUrl,
                      VideoUrl = video.VideoUrl

                  }).Take(count).ToListAsync();
        }
        public async Task<int> AddNewVideo(AllVideoViewModel model)
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


            await this.context.Video.AddAsync(newVideo);
            await this.context.SaveChangesAsync();

            return newVideo.Id;
        }
    }
}
