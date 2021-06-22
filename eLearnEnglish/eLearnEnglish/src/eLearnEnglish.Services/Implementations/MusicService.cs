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
    public class MusicService: DataService, IMusicService
    {
        public MusicService(QuizaldoDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Music>> GetAllMusic()
        {
            return await this.context.Music
                .ToListAsync();
        }


        public async Task<IEnumerable<AllMusicViewModel>> GetMusic()
        {
            return await this.context.Music.Select(x => new AllMusicViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync();
        }






        int MusicId;
        public async Task<AllMusicViewModel> GetMusicById(int id)
        {
            MusicId = id;
            return await this.context.Music.Where(x => x.Id == id)
                 .Select(music => new AllMusicViewModel()
                 {
                     Author = music.Author,
                     Genre = music.Genre,
                     Description = music.Description,
                     Difficulty = music.Difficulty,
                     Id = music.Id,
                     Title = music.Title,
                     CoverImageUrl = music.CoverImageUrl,
                     MusicUrl = music.MusicUrl
                 }).FirstOrDefaultAsync();
        }
        public async Task DeleteMusic(int id)
        {
            var music = await this.context.Music.FirstOrDefaultAsync(j => j.Id == id);

            if (music == null)
            {
                return;
            }

            this.context.Music.Remove(music);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<AllMusicViewModel>> GetTopMusicAsync(int count)
        {
            return await this.context.Music
                  .Select(music => new AllMusicViewModel()
                  {
                      Author = music.Author,
                      Genre = music.Genre,
                      Description = music.Description,
                      Difficulty = music.Difficulty,
                      Id = music.Id,
                      Title = music.Title,
                      CoverImageUrl = music.CoverImageUrl,
                      MusicUrl = music.MusicUrl

                  }).Take(count).ToListAsync();
        }

        public async Task<List<AllMusicViewModel>> GetDownMusicAsync(string difficulty, int count)
        {
            return await this.context.Music.Where(x => x.Difficulty == difficulty && x.Id != MusicId)
                  .Select(music => new AllMusicViewModel()
                  {
                      Author = music.Author,
                      Genre = music.Genre,
                      Description = music.Description,
                      Difficulty = music.Difficulty,
                      Id = music.Id,
                      Title = music.Title,
                      CoverImageUrl = music.CoverImageUrl,
                      MusicUrl = music.MusicUrl

                  }).Take(count).ToListAsync();
        }
        public async Task<int> AddNewMusic(AllMusicViewModel model)
        {
            var newMusic = new Music()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                Genre = model.Genre,
                Difficulty = model.Difficulty,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                MusicUrl = model.MusicUrl
            };


            await this.context.Music.AddAsync(newMusic);
            await this.context.SaveChangesAsync();

            return newMusic.Id;
        }

    }
}
