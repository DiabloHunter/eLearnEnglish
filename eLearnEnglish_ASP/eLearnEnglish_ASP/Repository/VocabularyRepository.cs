using eLearnEnglish_ASP.Data;
using eLearnEnglish_ASP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Repository
{
    public class VocabularyRepository : IVocabularyRepository
    {
        private readonly ApplicationDbContext _context = null;
        public VocabularyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VocabularyModel>> GetAllWords(int id)
        {
            var words = _context.Vocabulary.Include(p => p.Id);
            return await _context.Vocabulary.Select(x => new VocabularyModel()
            {
                Id = x.Id,
                UserId = x.UserId

            }).ToListAsync();
        }



    }
}
