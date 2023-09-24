namespace Academy.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; } 
        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public double NoOfHours { get; set; }
        public double Cost { get; set; }
    }
}
