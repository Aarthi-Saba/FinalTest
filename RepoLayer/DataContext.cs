using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pocos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RepoLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            string connection = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(
                entity => {
                    entity.HasOne(s => s.StudentCourse)
                        .WithMany(c => c.Students)
                        .HasForeignKey(s => s.CourseId);
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
