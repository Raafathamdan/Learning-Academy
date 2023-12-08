namespace Learning_Academy.DTO.Instructor
{
    public class UpdateInstructorDTO
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string InstructorEmail { get; set; }
        public string InstructorPhoneNumber { get; }
        public string Expertise { get; set; }
       
    }
}
