using eLearnEnglish_ASP.Data;
using eLearnEnglish_ASP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Repository
{
    public class WordRepository
    {
        private readonly ApplicationDbContext _context = null;

        public WordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WordModel>> GetWord()
        {
            return await _context.Word.Select(x => new WordModel()
            {
                Id = x.Id,
                Exprassion = x.Exprassion,
                WordTranslation = x.WordTranslation,
                Example = x.Example,
                ExampleTranslation = x.ExampleTranslation,
                Difficulty = x.Difficulty,
                Wrong1 = x.Wrong1,
                Wrong2 = x.Wrong2,
                Wrong3 = x.Wrong3
            }).ToListAsync();
        }
        public async Task<List<WordModel>> GetAllWord()
        {
            return await _context.Word
                  .Select(word => new WordModel()
                  {
                      Id = word.Id,
                      Exprassion = word.Exprassion,
                      WordTranslation = word.WordTranslation,
                      Example = word.Example,
                      ExampleTranslation = word.ExampleTranslation,
                      Difficulty = word.Difficulty,
                      Wrong1 = word.Wrong1,
                      Wrong2 = word.Wrong2,
                      Wrong3 = word.Wrong3
                  }).ToListAsync();
        }
    }
}
