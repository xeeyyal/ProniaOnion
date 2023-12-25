using AutoMapper;
using ProniaOnionAB104.Application.DTOs.Product;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetDto>().ReverseMap();
            CreateMap<Product, ProductItemDto>().ReverseMap();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}
