using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.ValueObjects;

namespace Backend.Application.UseCases.Products.CreateProduct;

public record CreateSsdRequest : CreateRequestBase
{
    public required int CapacityInGb { get; init; }
    public required OperationSpeed OperationSpeed { get; init; }
    public required StorageInterface StorageInterface { get; init; }
}

public class CreateSsdRequestHandler(
    IProductRepository<Ssd> productRepository,
    IFileService<Ssd> fileService) 
    : CreateProductRequestHandlerBase<CreateSsdRequest, Ssd>(productRepository, fileService)
{
    protected override Ssd CreateProduct(CreateSsdRequest request, string imagePath)
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
            InitialPrice = request.InitialPrice,
            Quantity = request.Quantity
        };
    }
}