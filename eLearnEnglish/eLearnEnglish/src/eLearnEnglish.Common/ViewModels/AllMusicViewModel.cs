using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizaldo.Common.ViewModels
{
    public class AllMusicViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Difficulty { get; set; }
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string MusicUrl { get; set; }
    }
}
