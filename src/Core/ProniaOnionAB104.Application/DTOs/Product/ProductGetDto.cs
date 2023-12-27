using ProniaOnionAB104.Application.DTOs.Categories;
using ProniaOnionAB104.Application.DTOs.Colors;
using ProniaOnionAB104.Application.DTOs.Tags;

namespace ProniaOnionAB104.Application.DTOs.Product
{
    public record ProductGetDto(int Id, string Name, decimal Price, string SKU, string? Description,
        int CategoryId, IncludeCategoryDto Category,
        int ColorId ,IncludeColorDto Color,
        int TagId,IncludeTagDto Tag);
}
