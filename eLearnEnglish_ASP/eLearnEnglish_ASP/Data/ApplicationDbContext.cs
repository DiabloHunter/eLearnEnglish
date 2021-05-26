using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using eLearnEnglish_ASP.Models;

namespace eLearnEnglish_ASP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Music> Music { get; set; }
        public DbSet<Video> Video { get; set; }

        public DbSet<Word> Word { get; set; }
        public DbSet<Vocabulary> Vocabulary { get; set; }
        /*public IEnumerable<object> Word { get; internal set; }*/
    }
}
