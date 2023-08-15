using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class CourseBranche
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey("Branche")]
        public int BrancheId { get; set; }
        public Branche Branche { get; set; }
    }
}
