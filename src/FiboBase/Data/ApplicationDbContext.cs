using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HarmonicPatternsBase.Models;

namespace HarmonicPatternsBase.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<HarmonicPattern> HarmonicPatterns { get; set; }
        public DbSet<Pattern> Patterns { get; set; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<PatternDirect> PatternDirects { get; set; }
        public DbSet<ReactionLvl> ReactionLvls { get; set; }

    }
}
