using Microsoft.EntityFrameworkCore;

using ProjectTracker.DAL.Models;

using System.Collections.Generic;

namespace ProjectTracker.DAL
{
    public class ProjectTrackerDbContext : DbContext
    {
        public ProjectTrackerDbContext()
        {
        }

        public ProjectTrackerDbContext(DbContextOptions<ProjectTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "DataSource=temp.db";
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectTaskField> ProjectTaskFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .ToTable("Projects")
                .HasMany(t => t.Tasks).WithOne(t => t.Project);

            modelBuilder.Entity<ProjectTask>()
                .ToTable("ProjectTasks")
                .HasMany(t => t.Fields).WithOne(f => f.Task);

            modelBuilder.Entity<ProjectTaskField>()
                .ToTable("ProjectTaskFields")
                .HasKey(nameof(ProjectTaskField.TaskId), nameof(ProjectTaskField.Name));

            base.OnModelCreating(modelBuilder);
        }
    }
}
