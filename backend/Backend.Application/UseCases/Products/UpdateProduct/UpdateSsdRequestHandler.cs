using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.ValueObjects;

namespace Backend.Application.UseCases.Products.UpdateProduct;

public record UpdateSsdRequest : UpdateRequestBase
{
    public required int CapacityInGb { get; init; }
    public required OperationSpeed OperationSpeed { get; init; }
    public required StorageInterface StorageInterface { get; init; }
}

public class UpdateSsdRequestHandler(
    IProductRepository<Ssd> productRepository,
    IFileService<Ssd> fileService)
    : UpdateProductRequestHandlerBase<UpdateSsdRequest, Ssd>(productRepository, fileService)
{
    protected override Ssd CreateProduct(UpdateSsdRequest request, string imagePath)
    {
        return new Ssd
        {
            BrandId = request.BrandId,
            DiscountPercentage = request.DiscountPercentage,
            CapacityInGb = request.CapacityInGb,
            OperationSpeed = request.OperationSpeed,
            StorageInterface = request.StorageInterface,
            ModelName = request.ModelName,
            ImagePath = imagePath,
            InitialPrice = request.Price,
            Quantity = request.Quantity
        };
    }
}