using System.Net;
using Backend.Application.Interfaces.Common;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Products;

public class DeleteProductRequestHandlerBase<TRequest, TProduct>(IProductRepository<TProduct> productRepository) : IRequestHandler<TRequest, Result<Unit>> 
    where TRequest : IRequest<Result<Unit>>, IDeleteRequest
    where TProduct : ProductBase
{
    public async Task<Result<Unit>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await productRepository.DeleteAsync(request.Id, cancellationToken);
        return Result<Unit>.Success(HttpStatusCode.NoContent, Unit.Value);
    }
}