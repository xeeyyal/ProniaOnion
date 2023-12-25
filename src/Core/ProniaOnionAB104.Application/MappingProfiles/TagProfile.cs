using AutoMapper;
using ProniaOnionAB104.Application.DTOs.Tags;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Application.MappingProfiles
{
    public class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagItemDto>();
            CreateMap<Tag, TagGetDto>();
            CreateMap<TagCreateDto, Tag>();
        }
    }
}
