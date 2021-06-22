using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quizaldo.Common.ViewModels
{
    public class AllVideoViewModel
    {
       public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string CoverImageUrl { get; set; }
        public IFormFile CoverPhoto { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string VideoUrl { get; set; }
    }
}
