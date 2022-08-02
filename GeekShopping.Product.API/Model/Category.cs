using GeekShooping.Product.API.Model.Base;

namespace GeekShooping.Product.API.Model
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }

        public DateTime? Created { get; set; }

        public Category() { }
    }
}
