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
    public class MusicRepository : IMusicRepository
    {
        private readonly ApplicationDbContext _context = null;
        private readonly IConfiguration _configuration;

        public MusicRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<int> AddNewMusic(MusicModel model)
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


            await _context.Music.AddAsync(newMusic);
            await _context.SaveChangesAsync();

            return newMusic.Id;
        }

        public async Task<List<MusicModel>> GetAllMusic()
        {
            return await _context.Music
                  .Select(music => new MusicModel()
                  {
                      Author = music.Author,
                      Genre = music.Genre,
                      Description = music.Description,
                      Difficulty = music.Difficulty,
                      Id = music.Id,
                      Title = music.Title,
                      CoverImageUrl = music.CoverImageUrl,
                      MusicUrl = music.MusicUrl

                  }).ToListAsync();
        }

        public async Task<List<MusicModel>> GetTopMusicAsync(int count)
        {
            return await _context.Music
                  .Select(music => new MusicModel()
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
        public async Task<MusicModel> GetMusicById(int id)
        {
            return await _context.Music.Where(x => x.Id == id)
                 .Select(music => new MusicModel()
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


        public async Task<List<MusicModel>> GetDownMusicAsync(string difficulty, int count)
        {
            return await _context.Music.Where(x => x.Difficulty == difficulty)
                  .Select(music => new MusicModel()
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



        public List<MusicModel> SearchMusic(string title, string author)
        {
            return null;
        }
        public string GetAppName()
        {
            return _configuration["AppName"];
        }
    }
}
