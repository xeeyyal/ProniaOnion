using AutoMapper;
using ProniaOnionAB104.Application.DTOs.Colors;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Application.MappingProfiles
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color,ColorItemDto>().ReverseMap();
            CreateMap<Color, ColorGetDto>().ReverseMap();
            CreateMap<ColorUpdateDto, Color>();

        }
    }
}
