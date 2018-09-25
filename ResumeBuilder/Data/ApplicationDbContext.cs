using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeBuilderContext.Models;

namespace ResumeBuilderContext.Data
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

        public DbSet<ResumeBuilderContext.Models.Applicant> Applicant { get; set; }

        public DbSet<ResumeBuilderContext.Models.Education> Education { get; set; }

        public DbSet<ResumeBuilderContext.Models.JobHistory> JobHistory { get; set; }

        public DbSet<ResumeBuilderContext.Models.Portfolio> Portfolio { get; set; }

        public DbSet<ResumeBuilderContext.Models.References> References { get; set; }

        public DbSet<ResumeBuilderContext.Models.Skills> Skills { get; set; }

        public DbSet<ResumeBuilderContext.Models.Position> Position { get; set; }

        public DbSet<ResumeBuilderContext.Models.Duties> Duties { get; set; }
    }
}
