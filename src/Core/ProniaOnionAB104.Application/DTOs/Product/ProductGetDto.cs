using ProniaOnionAB104.Application.DTOs.Categories;

namespace ProniaOnionAB104.Application.DTOs.Product
{
    public record ProductGetDto(int Id, string Name, decimal Price, string SKU, string? Description, int CategoryId, IncludeCategoryDto Category);
}
