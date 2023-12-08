namespace Learning_Academy.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }
        public virtual  List<Instructor> Instructor { get; set; }
        public virtual Category category { get;set; }

    }
}
