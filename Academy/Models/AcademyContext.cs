using Microsoft.EntityFrameworkCore;

namespace Academy.Models
{
    public class AcademyContext:DbContext
    {
        public DbSet<Branche> Branches { get; set; }
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


