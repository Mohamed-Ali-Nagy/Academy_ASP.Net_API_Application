using Microsoft.EntityFrameworkCore;

namespace Academy.Models
{
    public class AcademyContext:DbContext
    {
        public AcademyContext(DbContextOptions options) : base(options) { }
        public AcademyContext() :base() { }
        public DbSet<Branche> Branches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseBranche> CoursesBranches { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<SubjectCourse> SubjectsCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AcademySystem;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseBranche>().HasKey(cb => new
            {
                cb.CourseId,
                cb.BrancheId,
            });
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new
            {
               sc.StudintId,
               sc.CourseId,
            });

            modelBuilder.Entity<SubjectCourse>().HasKey(sc => new
            {
                sc.SubjectId,
                sc.CourseId,
            });
        }
    }
    }


