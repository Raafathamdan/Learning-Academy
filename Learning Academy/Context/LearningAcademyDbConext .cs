using Learning_Academy.Models;
using Learning_Academy.Models.EntityConfigartion;
using Microsoft.EntityFrameworkCore;

namespace Learning_Academy.Context
{
    public class LearningAcademyDbConext:DbContext
    {
        public LearningAcademyDbConext(DbContextOptions<LearningAcademyDbConext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigartion());
            modelBuilder.ApplyConfiguration(new CourseConfigartion());
            modelBuilder.ApplyConfiguration(new InstructorConfigartion());
            modelBuilder.ApplyConfiguration(new UserConfigartion());
        }
       public virtual DbSet<Category> Categories { get; set; }
       public virtual DbSet<Course> Courses { get; set; }
       public virtual DbSet<Instructor> Instructors { get; set; }
       public virtual DbSet<User> Users { get; set; }
    }
}
