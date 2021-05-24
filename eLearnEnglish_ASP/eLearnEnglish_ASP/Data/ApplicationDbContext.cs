using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using eLearnEnglish_ASP.Models;

namespace eLearnEnglish_ASP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<eLearnEnglish_ASP.Models.MusicModel> MusicModel { get; set; }
        public DbSet<eLearnEnglish_ASP.Models.VideoModel> VideoModel { get; set; }
    }
}
