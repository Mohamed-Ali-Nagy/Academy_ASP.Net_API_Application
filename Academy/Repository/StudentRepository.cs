using Academy.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AcademyContext context;
        public StudentRepository(AcademyContext _context)
        {
            context = _context;
        }

        public void Add(Student student)
        {
            context.Students.Add(student);
        }
        public void Delete(Student student)
        {
            context.Students.Remove(student);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public List<Student> GetAll()
        {
            return context.Students.Include(s=>s.Branche).ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Include(s=>s.Branche).FirstOrDefault(s => s.Id == id);
        }

        public void Update(Student student)
        {
            context.Update(student);
        }
    }
}
