using Academy.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The subject name is required")]
        public string SubjectName { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        //Navigation prop
        public Course Course { get; set;}
    }
}
