using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class SubjectCourse
    {
        [ForeignKey(nameof(Subject))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
