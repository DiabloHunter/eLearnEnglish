using eLearnEnglish_ASP.Data;
using eLearnEnglish_ASP.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Repository
{
    public class ManageSiteDataRepository
    {
        private readonly ApplicationDbContext _context = null;
        private readonly IConfiguration _configuration;

        public ManageSiteDataRepository(ApplicationDbContext context, IConfiguration configuration)
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
        public async Task<int> AddNewWord(WordModel model)
        {
            var newWord = new Word()
            {
                Exprassion = model.Exprassion,
                WordTranslation = model.WordTranslation,
                Example = model.Example,
                ExampleTranslation = model.ExampleTranslation

            };


            await _context.Word.AddAsync(newWord);
            await _context.SaveChangesAsync();

            return newWord.Id;
        }
    }
}
