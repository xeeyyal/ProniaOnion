using AutoMapper;
using ProniaApi.Application.DTOs.Category;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Application.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryItemDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
