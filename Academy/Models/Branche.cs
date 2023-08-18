using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Branche
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string SupervisorName { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //Navigation prop
        public virtual List<Student> Students { get; set; } = new List<Student>();
        public virtual List<CourseBranche> Courses { get; set; }= new List<CourseBranche>();
    }
}
