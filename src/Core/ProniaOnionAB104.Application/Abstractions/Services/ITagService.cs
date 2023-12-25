using ProniaOnionAB104.Application.DTOs.Tags;

namespace ProniaOnionAB104.Application.Abstractions.Services
{
    public interface ITagService
    {
        Task<ICollection<TagItemDto>> GetAllAsync(int page, int take);
        Task<TagGetDto> GetAsync(int id);
        Task CreateAsync(TagCreateDto tagDto);
        Task UpdateAsync(int id, TagUpdateDto tagDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
