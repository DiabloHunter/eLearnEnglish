using eLearnEnglish.Models;
using Quizaldo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizaldo.Common.ViewModels
{
    public class UserResultViewModel
    {

        public User User { get; set; }

        public Quiz Quiz { get; set; }

        public int UsersCorrectAnswers { get; set; }

        public int UsersWrongAnswers { get; set; }

        public int PointsEarned { get; set; }
    }
}
