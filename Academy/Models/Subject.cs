using Academy.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The subject name is required")]
        public string SubjectName { get; set; }

        //Navigation prop
        public virtual List<SubjectCourse> Courses { get; set; } = new List<SubjectCourse>();
    }
}
