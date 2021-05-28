using eLearnEnglish_ASP.Models;
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
        public ICollection<Word> Words { get; set; }
        public Vocabulary()
        {
            Words = new List<Word>();
        }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
