using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Course
    {
        public int Id { get; set; } = 0;
        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public double NoOfHours { get; set; }
        public double Cost { get; set; }

        //Navigation prop

        public virtual List<StudentCourse> Students { get; set; } = new List<StudentCourse>();

        public virtual List<Subject> Subjects { get; set; }=new List<Subject>();

    }
}
