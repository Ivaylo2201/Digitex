using Backend.Application.DTOs.Review;

namespace Backend.Application.DTOs.Product;

public record ProductLongDto : ProductShortDto
{
    public ICollection<ReviewDto> Reviews { get; init; } = [];
}
