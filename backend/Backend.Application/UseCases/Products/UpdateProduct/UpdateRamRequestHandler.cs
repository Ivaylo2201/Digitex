using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.ValueObjects;

namespace Backend.Application.UseCases.Products.UpdateProduct;

public record UpdateRamRequest : UpdateRequestBase
{
    public required Memory Memory { get; init; }
    public required string Timing { get; init; }
}

public class UpdateRamRequestHandler(
    IProductRepository<Ram> productRepository,
    IFileService<Ram> fileService)
    : UpdateProductRequestHandlerBase<UpdateRamRequest, Ram>(productRepository, fileService)
{
    protected override Ram CreateProduct(UpdateRamRequest request, string imagePath)
    {
        return new Ram
        {
            BrandId = request.BrandId,
            DiscountPercentage = request.DiscountPercentage,
            Memory = request.Memory,
            Timing = request.Timing,
            ModelName = request.ModelName,
            ImagePath = imagePath,
            InitialPrice = request.Price,
            Quantity = request.Quantity
        };
    }
}