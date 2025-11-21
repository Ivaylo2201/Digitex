namespace Backend.Application.Dtos.Admin;

public record AddSuggestionDto
{
    public required Guid ProductId { get; init; }
    public required Guid SuggestedProductId { get; init; }
}