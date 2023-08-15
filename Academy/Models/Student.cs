using Academy.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int NationalID { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int LandlinePhone { get; set; }

        public string Qualification { get; set; }
        public int QualificationObtainingYear { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime SubmissionDate { get; set; }

        public string Religion { get; set; }


        public MilitaryStatus MilitaryStatus { get; set; }

        //Navigation prop
        [ForeignKey(nameof(Branche))]
        public int BrancheId { get; set; }
        public Branche Branche { get; set; }

        public virtual List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}
