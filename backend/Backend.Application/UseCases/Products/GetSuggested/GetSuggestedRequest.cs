using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Products.GetSuggested;

public record GetSuggestedRequest : IRequest<Result<IEnumerable<SuggestedProductDto>>>
{
    public required Guid ProductId { get; init; }
}