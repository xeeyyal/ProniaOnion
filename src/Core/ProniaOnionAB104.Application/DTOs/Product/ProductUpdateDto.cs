namespace ProniaOnionAB104.Application.DTOs.Product
{
    public record ProductUpdateDto(string Name, decimal Price, string SKU, string? Description, int CategorId, ICollection<int> ColorIds, ICollection<int> TagIds);
}
