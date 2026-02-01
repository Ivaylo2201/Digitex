using System.Net;
using Backend.Application.Interfaces.Common;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using MediatR;

namespace Backend.Application.UseCases.Products;

public abstract class CreateProductRequestHandlerBase<TRequest, TProduct>(
    IProductRepository<TProduct> productRepository,
    IFileService<TProduct> fileService) : IRequestHandler<TRequest, Result<Unit>> 
    where TRequest : IRequest<Result<Unit>>, ICreateRequest
    where TProduct : ProductBase
{
    public async Task<Result<Unit>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var imagePath = await fileService.SaveFileAsync(request.Image);
        await productRepository.CreateAsync(CreateProduct(request, imagePath), cancellationToken);
        
        return Result<Unit>.Success(HttpStatusCode.Created, Unit.Value);
    }

    protected abstract TProduct CreateProduct(TRequest request, string imagePath);
}