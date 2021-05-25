using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearnEnglish_ASP.Data
{
    public class Word
    {
        public int Id { get; set; }
        public string Exprassion { get; set; }
        public string WordTranslation { get; set; }
        public string Example { get; set; }
        public string ExampleTranslation { get; set; }
        public ICollection<Vocabulary> Vocabulary { get; set; }
    }
}
