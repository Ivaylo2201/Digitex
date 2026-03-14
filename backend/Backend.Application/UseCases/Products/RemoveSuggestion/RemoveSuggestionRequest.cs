using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Products.RemoveSuggestion;

public record RemoveSuggestionRequest : IRequest<Result<Unit>>
{
    public required Guid ProductId { get; init; }
    public required Guid SuggestedProductId { get; init; }
}