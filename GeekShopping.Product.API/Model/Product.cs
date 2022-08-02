using GeekShooping.Product.API.Model.Base;
using GeekShooping.Product.API.Model.Enum;

namespace GeekShooping.Product.API.Model
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public ProductType? ProductType { get; set; }

        public DateTime? Created { get; set; }

        public long? CategoryId { get; set; }

        public Category? Category { get; set; }

        public Product() { }
    }
}
