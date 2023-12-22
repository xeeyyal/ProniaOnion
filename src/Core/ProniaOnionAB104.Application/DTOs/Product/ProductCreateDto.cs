namespace ProniaApi.Application.DTOs.Product
{
	public record ProductCreateDto(string Name,decimal Price, string SKU, string? Description, int CategoryId,ICollection<int>ColorIds);
}
