﻿using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.DormitoryManagement;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.Forest;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.Models.TrainManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hogwarts.Core.Data
{
    public class HogwartsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Dormitory> Dormitories { get; set; }

        public DbSet<DormitoryRoom> Rooms { get; set; }
        public DbSet<ActivationCode> ActivationCodes { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Train> Trains { get; set; }

        public DbSet<TrainTicket> Tickets { get; set; } 


        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlite(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>()
                .HasMany(t => t.Tickets)
                .WithOne(tt => tt.Train)
                .HasForeignKey(tt => tt.TrainId);

            modelBuilder.Entity<Dormitory>()
                .HasMany(d => d.Rooms)
                .WithOne(dr => dr.Dormitory)
                .HasForeignKey(dr => dr.DormitoryId);
        }
    }
}
