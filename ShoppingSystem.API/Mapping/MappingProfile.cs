using AutoMapper;
using ShoppingSystem.API.Helpers;


namespace ShoppingSystem.API.Mapping
{
    public class MappingProfile : Profile
    {
        /*Inheritance from Profile class is used to define mapping rules between models.
    It allows you to group related mappings in one place*/
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                 .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                 .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                 /*.ForMember(d => d.PictureUrl, o => o.MapFrom(s => $"https://localhost:7265/{s.PictureUrl}"))*/
                 .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());


        }
    }
}
