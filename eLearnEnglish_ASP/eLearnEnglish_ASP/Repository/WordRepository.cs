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
                ExampleTranslation = x.ExampleTranslation
            }).ToListAsync();
        }
    }
}
