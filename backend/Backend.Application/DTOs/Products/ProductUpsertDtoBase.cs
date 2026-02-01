using Microsoft.AspNetCore.Http;

namespace Backend.Application.DTOs.Products;

public record ProductUpsertDtoBase
{
    public required int BrandId { get; init; }
    public required string ModelName { get; init; }
    public required decimal InitialPrice { get; set; }
    public int DiscountPercentage { get; init; }
    public required int Quantity { get; set; }
    public required IFormFile Image { get; init; }
}