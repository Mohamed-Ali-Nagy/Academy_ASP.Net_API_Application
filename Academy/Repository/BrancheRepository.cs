using Academy.Data.Repository;
using Academy.Models;

namespace Academy.Data.Services
{
    public class BrancheRepository : IBrancheRepository
    {
        private readonly AcademyContext context;
        public BrancheRepository(AcademyContext _context)
        {
            context = _context;
        }
        public void Add(Branche branche)
        {
            context.Branches.Add(branche);

        }

        public void Delete(Branche branche)
        {
            context.Branches.Remove(branche);
        }

        public List<Branche> GetAll()
        {
           return context.Branches.ToList();
        }

        public Branche GetById(int id)
        {
            return context.Branches.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Branche branche)
        {
            Branche oldBranche=context.Branches.Find(branche.Id);
            context.Branches.Update(oldBranche);
        }
    }
}
