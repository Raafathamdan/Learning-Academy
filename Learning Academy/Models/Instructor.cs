namespace Learning_Academy.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set;}
        public string InstructorEmail { get; set;}
        public string InstructorPhoneNumber { get; set; }
        public string Expertise { get; set; }
        public DateTime JoinDate { get; set;}
        public virtual List<Course> course { get; set;}

    }
}
