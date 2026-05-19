using Microsoft.EntityFrameworkCore;
using EnrolmentSystem.Model;
using EnrolmentSystem.Service;

namespace EnrolmentSystem.Service
{
    public class EnrolmentDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }


        // Configure the database connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EnrolmentDB;Trusted_Connection=true;");
        }

        // Configure the model relationships and constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Student>(entity
            //    =>
            //{
            //    entity.HasKey(e => new { e.StudentID });
            //    entity.Property(e => e.StudentName).HasMaxLength(50);
            //    entity.Property(e => e.DateEnroled).HasColumnType("date");

            //});

            //modelBuilder.Entity<Course>(entity =>
            //{
            //    entity.HasKey(e => new { e.CourseID });
            //    entity.Property(e => e.CourseName).HasMaxLength(50);
            //    entity.Property(e => e.Cost).HasColumnType("double");
            //});


            modelBuilder.Entity<Enrolment>(entity =>
            {
                entity.HasKey(e => new { e.StudentID, e.CourseID });

                entity.Property(e => e.Grade).HasMaxLength(10);

                entity.HasOne<Student>().WithMany().HasForeignKey(e => e.StudentID);

                entity.HasOne<Course>().WithMany().HasForeignKey(e => e.CourseID);
            });
        }
    }
}
