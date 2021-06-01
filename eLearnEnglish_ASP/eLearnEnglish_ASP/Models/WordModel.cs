using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Models
{
    public class WordModel
    {
        public int Id { get; set; }
        public string Exprassion { get; set; }
        public string WordTranslation { get; set; }
        public string Example { get; set; }
        public string ExampleTranslation { get; set; }

        public string Difficulty { get; set; }

        public string Wrong1 { get; set; }
        public string Wrong2 { get; set; }
        public string Wrong3 { get; set; }

    }
}
