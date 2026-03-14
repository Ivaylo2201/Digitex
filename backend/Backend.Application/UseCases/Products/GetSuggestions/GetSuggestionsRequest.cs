using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Products.GetSuggestions;

public record GetSuggestionsRequest : IRequest<Result<IEnumerable<SuggestedProductDto>>>
{
    public required Guid ProductId { get; init; }
}