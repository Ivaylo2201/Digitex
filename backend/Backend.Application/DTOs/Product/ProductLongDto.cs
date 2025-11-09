using Backend.Application.DTOs.Review;

namespace Backend.Application.DTOs.Product;

public record ProductLongDto : ProductShortDto
{
    public required string Sku { get; init; }
    public ICollection<ReviewDto> Reviews { get; init; } = [];
}
