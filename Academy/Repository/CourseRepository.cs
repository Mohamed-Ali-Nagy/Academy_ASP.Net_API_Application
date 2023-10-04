using Academy.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AcademyContext context;
       public CourseRepository(AcademyContext _context)
        {
            context = _context;
        }
        public void Add(Course course)
        {
            context.Courses.Add(course);
        }

        public void Delete(Course course)
        {
            context.Courses.Remove(course);
        }

        public List<Course> GetAll()
        {
           return context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return context.Courses.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Course course)
        {
            context.Update(course);
        }
    }
}
