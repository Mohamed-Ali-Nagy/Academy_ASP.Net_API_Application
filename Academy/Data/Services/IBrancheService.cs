using Academy.Models;

namespace Academy.Data.Services
{
    public interface IBrancheService
    {
        List<Branche> GetAll();
        void Delete(Branche branche);
        Branche GetById(int id);
        void Add(Branche branche);
        void Update(Branche branche);
        void Save();

    }
}
