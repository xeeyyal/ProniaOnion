using Microsoft.EntityFrameworkCore;
using ProniaOnionAB104.Application.Abstractions.Repositories;
using ProniaOnionAB104.Application.Abstractions.Services;
using ProniaOnionAB104.Application.DTOs.Tags;
using ProniaOnionAB104.Domain.Entities;

namespace ProniaOnionAB104.Persistence.Implementations.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(TagCreateDto tagCreateDto)
        {
            Tag tag = new Tag
            {
                Name = tagCreateDto.Name
            };
            await _repository.AddAsync(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<TagItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> tags = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, IsTracking: false, isDeleted: true).ToListAsync();

            ICollection<TagItemDto> tagItemDtos = new List<TagItemDto>();

            foreach (Tag tag in tags)
            {
                tagItemDtos.Add(new TagItemDto(tag.Id, tag.Name));
            }
            return tagItemDtos;
        }
        public async Task UpdateAsync(int id, TagUpdateDto tagUpdateDto)
        {
            Tag tag = await _repository.GetByIdAsync(id);

            if (tag is null) throw new Exception("Not found");

            tag.Name = tagUpdateDto.Name;

            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);

            if (tag is null) throw new Exception("Not found");

            _repository.Delete(tag);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not found");
            _repository.SoftDelete(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task<TagGetDto> GetAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not found");
            return new TagGetDto(tag.Id, tag.Name);
        }
    }
}
