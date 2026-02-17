using System.Net;
using Backend.Domain.Common;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Products.AddSuggestion;

public class AddSuggestionRequestHandler(IProductBaseRepository productBaseRepository) : IRequestHandler<AddSuggestionRequest, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(AddSuggestionRequest request, CancellationToken cancellationToken)
    {
        await productBaseRepository.AddSuggestionAsync(request.ProductId, request.SuggestedProductSku, cancellationToken);
        
        return Result<Unit>.Success(HttpStatusCode.OK, Unit.Value);
    }
}