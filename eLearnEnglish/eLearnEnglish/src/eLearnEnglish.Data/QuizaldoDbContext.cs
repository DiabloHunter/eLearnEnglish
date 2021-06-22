using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLearnEnglish.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quizaldo.Models;

namespace Quizaldo.Data
{
    public class QuizaldoDbContext : IdentityDbContext<User>
    {
        public QuizaldoDbContext(DbContextOptions<QuizaldoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Video> Video { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<UserResult> UserResults { get; set; }


    }
}
