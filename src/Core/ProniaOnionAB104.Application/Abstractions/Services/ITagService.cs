using ProniaApi.Application.DTOs.Tag;

namespace ProniaOnionAB104.Application.Abstractions.Services
{
    public interface ITagService
    {
        Task<ICollection<TagItemDto>> GetAllAsync(int page, int take);
        //Task<GetTagDto> GetAsync(int id);
        Task CreateAsync(TagCreateDto tagDto);
        Task UpdateAsync(int id, TagUpdateDto tagDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
