using Academy.Data.Enums;
using Academy.Models;

namespace Academy.DTO
{
    public class StudentDTO
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
        public int BrancheId { get; set; }
        public String BrancheName { get; set; }
    }
}
