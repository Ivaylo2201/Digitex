using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Products.AddSuggestion;

public record AddSuggestionRequest : IRequest<Result<Unit>>
{
    public required Guid ProductId { get; init; }
    public required Guid SuggestionProductId { get; init; }
}