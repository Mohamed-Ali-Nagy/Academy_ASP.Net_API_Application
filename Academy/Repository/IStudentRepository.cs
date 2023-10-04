using Academy.Models;

namespace Academy.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Update(Student student);
        public void Save();
        public void Add(Student student);
        public void Delete(Student student);
    }
}
