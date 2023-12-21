using AutoMapper;
using ProniaApi.Application.DTOs.Tag;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Application.MappingProfiles
{
    public class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagItemDto>();
            CreateMap<TagCreateDto, Tag>();
        }
    }
}
