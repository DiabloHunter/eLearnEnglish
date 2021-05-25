using eLearnEnglish_ASP.Data;
using eLearnEnglish_ASP.Models;
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

        public async Task<List<WordModel>> GetLanguages()
        {
            return await _context.Word.Select(x => new WordModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
