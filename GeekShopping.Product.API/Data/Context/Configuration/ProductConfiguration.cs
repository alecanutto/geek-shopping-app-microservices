using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShooping.Product.API.Model.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.ProductType).HasConversion<string>();
            builder.Property(p => p.ImageUrl).HasMaxLength(300);
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.Created).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
