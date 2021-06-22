using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace eLearnEnglish.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public int TotalQuizPoints { get; set; }

        public int TotalAchievementPoints { get; set; }

    }
}
