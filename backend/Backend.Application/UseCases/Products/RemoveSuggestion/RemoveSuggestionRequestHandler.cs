using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Products.RemoveSuggestion;

public class RemoveSuggestionRequestHandler(IProductBaseRepository productBaseRepository) : IRequestHandler<RemoveSuggestionRequest, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(RemoveSuggestionRequest request, CancellationToken cancellationToken)
    {
        await productBaseRepository.RemoveSuggestionAsync(request.ProductId, request.SuggestedProductSku, cancellationToken);
        
        return Result<Unit>.Success(HttpStatusCode.NoContent, Unit.Value);
    }
}