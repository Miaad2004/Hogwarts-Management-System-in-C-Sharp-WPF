using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.DormitoryManagement;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.ForestManagement;
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.Models.TrainManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq.Expressions;

namespace Hogwarts.Core.Data
{
    public class HogwartsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<DormitoryRoom> Rooms { get; set; }
        public DbSet<ActivationCode> ActivationCodes { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<StudentPlant> StudentPlants { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainTicket> Tickets { get; set; }
        public DbSet<House> Houses { get; set; }


        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return config.GetConnectionString("DefaultConnection") ?? throw new ConfigurationErrorsException("Invalid Configuration");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlite(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Train & Ticket => 1-n
            modelBuilder.Entity<Train>()
                .HasMany(t => t.Tickets)
                .WithOne(tt => tt.Train)
                .HasForeignKey(tt => tt.TrainId);

            // House & Student => 1-n
            modelBuilder.Entity<House>()
                 .HasMany(h => h.Students)
                 .WithOne(s => s.House)
                 .HasForeignKey(s => s.HouseId);

            // Dormitory & Room => 1-n
            modelBuilder.Entity<Dormitory>()
                .HasMany(d => d.Rooms)
                .WithOne(dr => dr.Dormitory)
                .HasForeignKey(dr => dr.DormitoryId);

            // Student & StudentPlant => 1-n
            modelBuilder.Entity<StudentPlant>()
                .HasOne(sp => sp.Student)
                .WithMany(p => p.StudentPlants)
                .HasForeignKey(sp => sp.StudentId);

            // Plant & StudentPlant => 1-n
            modelBuilder.Entity<StudentPlant>()
                .HasOne(sp => sp.Plant)
                .WithMany(p => p.StudentPlants)
                .HasForeignKey(sp => sp.PlantId);

            // Student & Grade => 1-n
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            // Course & Grade => 1-n
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId);

            // Student & Course => n-n
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students);

            // Student & StudentAssignment => 1-n
            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentAssignments)
                .WithOne(sa => sa.Student)
                .HasForeignKey(sa => sa.StudentId);

            // Course & Assignment => 1-n
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Assignments)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId);

            // Assignment & StudentAssignment => 1-n
            modelBuilder.Entity<Assignment>()
                .HasMany(a => a.StudentAssignments)
                .WithOne(sa => sa.Assignment)
                .HasForeignKey(sa => sa.AssignmentId);
        }

        public async Task<ObservableCollection<T>> GetListAsync<T>(
            Func<T, object> orderBy,
            Expression<Func<T, bool>> whereClause = null,
            params Expression<Func<T, object>>[] includeProperties
        ) where T : class
        {
            IQueryable<T> query = this.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (whereClause != null)
            {
                query = query.Where(whereClause);
            }

            var list = await Task.Run(() => query.OrderBy(orderBy).ToList());

            for (int i = 0; i < list.Count(); i++)
            {
                var item = list[i];
                var prop = item.GetType().GetProperty("SequentialIndex");
                prop?.SetValue(item, i + 1);
            }

            return new ObservableCollection<T>(list);
        }



    }
}
