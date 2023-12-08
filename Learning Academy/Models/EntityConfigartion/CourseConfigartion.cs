using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Learning_Academy.Models.EntityConfigartion
{
    public class CourseConfigartion : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.CourseId);
            builder.Property(x => x.CourseId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x => x.Location).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100);


            
        }
    }
}
