using Microsoft.EntityFrameworkCore;
using PlexBackend.Core.ContextModels;
using PlexBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Infrastructure
{
    public class PlexContext : DbContext
    {
        public PlexContext(DbContextOptions<PlexContext> options) : base(options)
        {

        }

        public DbSet<StudentChoice> StudentChoices { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
