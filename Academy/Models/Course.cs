using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The course name is required")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "The course description is required")]

        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "The course number of hours is required")]

        public double NoOfHours { get; set; }
        [Required(ErrorMessage = "The course cost is required")]

        public double Cost { get; set; }

        //Navigation prop

        public virtual List<StudentCourse> Students { get; set; } = new List<StudentCourse>();

        public virtual List<Subject> Subjects { get; set; }=new List<Subject>();

    }
}
