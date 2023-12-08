namespace Learning_Academy.DTO.Instructor
{
    public class CreateInstructorDTO
    {
        public string InstructorName { get; set; }
        public string InstructorEmail { get; set; }
        public string InstructorPhoneNumber { get; }
        public string Expertise { get; }
        public DateTime JoinDate { get; set; }
    }
}
