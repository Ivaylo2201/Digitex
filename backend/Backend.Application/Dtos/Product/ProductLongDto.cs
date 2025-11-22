using Backend.Application.Dtos.Review;

namespace Backend.Application.Dtos.Product;

public record ProductLongDto : ProductShortDto
{
    public required string Sku { get; init; }
    public ICollection<ReviewDto> Reviews { get; init; } = [];
    public ICollection<SuggestionDto> SuggestedProducts { get; init; } = [];
}
