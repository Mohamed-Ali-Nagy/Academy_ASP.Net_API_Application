using System.ComponentModel.DataAnnotations;

namespace Academy.Data.DTO
{
    public class BrancheDTO
    {
        public int BrancheId { get; set; } = 0;
        public string BrancheName { get; set; }
        //[RegularExpression("/\r\n^01[0125][0-9]{8}$\r\n/\r\ngm", ErrorMessage = "Invalid phone number")]
        public int BranchePhoneNumber { get; set; }
        public string BrancheSupervisorName { get; set; }



    }
}
