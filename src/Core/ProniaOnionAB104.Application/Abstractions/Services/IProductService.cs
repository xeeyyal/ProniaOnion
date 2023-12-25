using ProniaOnionAB104.Application.DTOs.Product;

namespace ProniaOnionAB104.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAllPaginatedAsync(int page, int take);
        Task<ProductGetDto> GetByIsAsync(int id);
        Task CreateAsync(ProductCreateDto productCreateDto);
        Task UpdateAsync(int id, ProductUpdateDto productUpdateDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
