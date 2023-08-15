using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class StudentCourse
    {
        [ForeignKey(nameof(Student))]
        public int StudintId { get; set; }
        public Student Student { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
