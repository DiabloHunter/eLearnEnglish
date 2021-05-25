using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Data
{
    public class Vocabulary
    {
        public int Id { get; set; }
        public List<Word> Words { get; set; }
        public ICollection<IdentityUser> User { get; set; }
    }
}
