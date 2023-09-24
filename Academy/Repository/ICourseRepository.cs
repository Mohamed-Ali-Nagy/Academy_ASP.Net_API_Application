using Academy.Models;

namespace Academy.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        void Delete(Course course);
        Course GetById(int id);
        void Add(Course course);
        void Update(Course course);
        void Save();
    }
}
