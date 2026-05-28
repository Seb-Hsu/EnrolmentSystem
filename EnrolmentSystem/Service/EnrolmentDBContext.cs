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
            optionsBuilder.UseSqlServer("Server=tcp:clp2026s1.database.windows.net,1433;Initial Catalog=EnrolmentDB;Persist Security Info=False;User ID=seb;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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

    public static class EnrolmentService
    {
        static EnrolmentDBContext cxt = new EnrolmentDBContext();
        static EnrolmentService()
        {
            //comment out if the database already exists
            using (var cxt = new EnrolmentDBContext())
            {
                //create db if not exists
                cxt.Database.EnsureCreated();

                //create some sample data if the database is empty
                var s1 = new Student { StudentID = "00123456", StudentName = "Alice Spring", DateEnroled = DateOnly.Parse("2023-01-01") };
                var s2 = new Student { StudentID = "004567898", StudentName = "Bob Summer", DateEnroled = DateOnly.Parse("2023-02-01") };

                cxt.Students.Add(s1);
                cxt.Students.Add(s2);
                cxt.SaveChanges();

                var c1 = new Course { CourseID = "C001", CourseName = "Introduction to Programming", Cost = 1000.00 };
                var c2 = new Course { CourseID = "C002", CourseName = "Data Structures and Algorithms", Cost = 1200.00 };
                cxt.Courses.Add(c1);
                cxt.Courses.Add(c2);
                cxt.SaveChanges();

                var e1 = new Enrolment { StudentID = s1.StudentID, CourseID = c1.CourseID, Grade = "A" };
                var e2 = new Enrolment { StudentID = s2.StudentID, CourseID = c2.CourseID, Grade = "B" };
                cxt.Enrolments.Add(e1);
                cxt.Enrolments.Add(e2);
                cxt.SaveChanges();
            }
        }

        // Get all students from the database
        public static List<Student> GetAllStudents()
        {
            var studentList = new List<Student>();
            foreach (var s in cxt.Students)
            {
                studentList.Add(s);
            }

            return studentList;
        }

        // Get all courses from the database
        public static List<Course> GetAllCourses()
        {
            var courseList = new List<Course>();
            foreach (var c in cxt.Courses)
            {
                courseList.Add(c);
            }

            return courseList;
        }

        // Get all enrolments from the database
        public static List<Enrolment> GetAllEnrolments()
        {
            var enrolmentList = new List<Enrolment>();
            foreach (var e in cxt.Enrolments)
            {
                enrolmentList.Add(e);
            }
            return enrolmentList;
        }

        // Add a new student to the database
        public static void AddStudent(Student s)
        {

            cxt.Database.EnsureCreated();
            cxt.Students.Add(s);
            cxt.SaveChanges();

        }

        // Add a new course to the database
        public static void AddCourse(Course c)
        {
            cxt.Database.EnsureCreated();
            cxt.Courses.Add(c);
            cxt.SaveChanges();
        }

        // Add a new enrolment to the database
        public static void AddEnrolment(Enrolment e)
        {
            cxt.Database.EnsureCreated();
            cxt.Enrolments.Add(e);
            cxt.SaveChanges();
        }
    }
}
