using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Learning_Academy.Models.EntityConfigartion
{
    public class InstructorConfigartion : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.InstructorId);
            builder.Property(x => x.InstructorId).IsRequired();
            builder.Property(x => x.InstructorEmail).IsRequired();
            builder.Property(x => x.InstructorName).IsRequired();
            builder.Property(x => x.InstructorPhoneNumber).IsRequired().HasMaxLength(14);
            builder.Property(x => x.JoinDate).IsRequired();
            builder.Property(x => x.Expertise).IsRequired().HasMaxLength(150);
        }
    }
}
