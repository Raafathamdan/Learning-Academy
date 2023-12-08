namespace Learning_Academy.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
       
        public string Title { get; set; }

        public string Discription { get; set; }
        public virtual List<Course> coruse { get; set; }


    }
}
