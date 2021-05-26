using eLearnEnglish_ASP.Data;
using eLearnEnglish_ASP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Repository
{
    public class VocabularyRepository
    {
        private readonly ApplicationDbContext _context = null;
        public VocabularyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VocabularyModel>> GetWord()
        {
            return await _context.Vocabulary.Select(x => new VocabularyModel()
            {
                Id = x.Id,
                WordId1 = x.WordId1,
                WordId2 = x.WordId2,
                WordId3 = x.WordId3,
                WordId4 = x.WordId4,
                WordId5 = x.WordId5,
                WordId6 = x.WordId6,
                WordId7 = x.WordId7,
                WordId8 = x.WordId8,
                WordId9 = x.WordId9,
                WordId10 = x.WordId10,
                WordId11 = x.WordId11,
                WordId12 = x.WordId12,
                WordId13 = x.WordId13,
                WordId14 = x.WordId14,
                WordId15 = x.WordId15,
                WordId16 = x.WordId16,
                WordId17 = x.WordId17,
                WordId18 = x.WordId18,
                WordId19 = x.WordId19,
                WordId20 = x.WordId20,

                WordId21 = x.WordId21,
                WordId22 = x.WordId22,
                WordId23 = x.WordId23,
                WordId24 = x.WordId24,
                WordId25 = x.WordId25,
                WordId26 = x.WordId26,
                WordId27 = x.WordId27,
                WordId28 = x.WordId28,
                WordId29 = x.WordId29,
                WordId30 = x.WordId30,

                WordId31 = x.WordId31,
                WordId32 = x.WordId32,
                WordId33 = x.WordId33,
                WordId34 = x.WordId34,
                WordId35 = x.WordId35,
                WordId36 = x.WordId36,
                WordId37 = x.WordId37,
                WordId38 = x.WordId38,
                WordId39 = x.WordId39,
                WordId40 = x.WordId40,

                WordId41 = x.WordId41,
                WordId42 = x.WordId42,
                WordId43 = x.WordId43,
                WordId44 = x.WordId44,
                WordId45 = x.WordId45,
                WordId46 = x.WordId46,
                WordId47 = x.WordId47,
                WordId48 = x.WordId48,
                WordId49 = x.WordId49,
                WordId50 = x.WordId50,

                WordId51 = x.WordId51,
                WordId52 = x.WordId52,
                WordId53 = x.WordId53,
                WordId54 = x.WordId54,
                WordId55 = x.WordId55,
                WordId56 = x.WordId56,
                WordId57 = x.WordId57,
                WordId58 = x.WordId58,
                WordId59 = x.WordId59,
                WordId60 = x.WordId60

            }).ToListAsync();
        }
    }
}
