using AutoMapper;
using GeekShooping.Product.API.Data.ValueObjects;

namespace GeekShooping.Product.API.Config.MapperConfig
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Model.Product>().ReverseMap();
                config.CreateMap<CategoryVO, Model.Category>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
