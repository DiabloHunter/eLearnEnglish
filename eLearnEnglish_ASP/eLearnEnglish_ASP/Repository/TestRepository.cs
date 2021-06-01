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
    public class TestRepository
    {
        private readonly ApplicationDbContext _context = null;
        private readonly IConfiguration _configuration;

        public TestRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<List<WordModel>> GetTestByLevel(string difficulty)
        {
            return await _context.Word.Where(x => x.Difficulty == difficulty)
                 .Select(test => new WordModel()
                 {
                     Exprassion = test.Exprassion,
                     WordTranslation = test.WordTranslation,
                 }).Take(20).ToListAsync();
        }
    }
}
