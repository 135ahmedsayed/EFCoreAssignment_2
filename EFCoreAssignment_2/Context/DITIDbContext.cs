
using EFCoreAssignment_2.Context.ConfigrationClasses;
using EFCoreAssignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment_2.Context
{
    internal class DITIDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Departments> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ClassConfiguration
            optionsBuilder.UseSqlServer("Server = . ; database = DITIDb ; Trusted_Connection = true; TrustServerCertificate = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ClassConfiguration
            modelBuilder.ApplyConfiguration(new StudentConfig());

            modelBuilder.Entity<StudCourse>(x =>
            {
                x.ToTable("StudCourses")
                 .HasKey(sc => new { sc.Stud_Id, sc.Course_Id });
                x.HasOne<Student>()
                 .WithMany(s => s.StudCourses)
                 .HasForeignKey(sc => sc.Stud_Id)
                 .OnDelete(DeleteBehavior.Restrict);
                x.HasOne<Courses>()
                 .WithMany(s => s.StudCourses)
                 .HasForeignKey(sc => sc.Course_Id)
                 .OnDelete(DeleteBehavior.Restrict);
            });
                

            // Department has Many Instructors
            modelBuilder.Entity<Instructors>()
                .HasOne(i => i.departments1)
                .WithMany(d => d.instructors)
                .HasForeignKey(i => i.Dep_id);

            // علاقة Instructor ↔ Department (إدارة / Manager)
            modelBuilder.Entity<Departments>()
                .HasOne(d => d.ManagerIns)
                .WithMany(i => i.departments)
                .HasForeignKey(d => d.Ins_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
