using Academy.Models;

namespace Academy.Data.Repository
{
    public interface IBrancheRepository
    {
        List<Branche> GetAll();
        void Delete(Branche branche);
        Branche GetById(int id);
        void Add(Branche branche);
        void Update(Branche branche);
        void Save();

    }
}
