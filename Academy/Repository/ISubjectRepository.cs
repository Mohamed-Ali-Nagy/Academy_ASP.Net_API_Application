using Academy.Models;

namespace Academy.Repository
{
    public interface ISubjectRepository
    {
        List<Subject> GetAll();
        void Delete(Subject subject);
        Subject GetById(int id);
        void Add(Subject subject);
        void Update(Subject subject);
        void Save();
    }
}
