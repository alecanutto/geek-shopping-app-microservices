using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShooping.Product.API.Model.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Created).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
