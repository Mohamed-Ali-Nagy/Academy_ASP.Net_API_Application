using Academy.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AcademyContext context;
        public SubjectRepository(AcademyContext _context)
        {
            context = _context;
        }
        public void Add(Subject subject)
        {
            context.Add(subject);
        }

        public void Delete(Subject subject)
        {
            context.Remove(subject);
        }

        public List<Subject> GetAll()
        {
            return context.Subjects.Include(c=>c.Course).ToList();
        }

        public Subject GetById(int id)
        {
           return context.Subjects.Include(c=>c.Course).FirstOrDefault(s=>s.Id==id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Subject subject)
        {
            context.Update(subject);
        }
    }
}
