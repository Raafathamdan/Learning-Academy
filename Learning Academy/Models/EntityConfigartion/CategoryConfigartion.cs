using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Learning_Academy.Models.EntityConfigartion
{
    public class CategoryConfigartion : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.Discription).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            
        }
    }
}
