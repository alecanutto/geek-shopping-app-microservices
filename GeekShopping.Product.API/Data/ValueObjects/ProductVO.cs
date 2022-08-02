using GeekShooping.Product.API.Model.Enum;

namespace GeekShooping.Product.API.Data.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ProductType ProductType { get; set; }
        public DateTime Created { get; set; }
        public CategoryVO Category { get; set; }
    }
}
