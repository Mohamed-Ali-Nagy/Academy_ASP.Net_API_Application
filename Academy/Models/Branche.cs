using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Branche
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The branche name is required")]
        public string BrancheName { get; set; }
        [Required(ErrorMessage = "The phone number  is required")]
        [RegularExpression("/\r\n^01[0125][0-9]{8}$\r\n/\r\ngm",ErrorMessage ="Invalid phone number")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "The supervisor name is required")]
        public string SupervisorName { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //Navigation prop
        public virtual List<Student> Students { get; set; } = new List<Student>();
        public virtual List<CourseBranche> Courses { get; set; }= new List<CourseBranche>();
    }
}
