using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.ValueObjects;

namespace Backend.Application.UseCases.Products.CreateProduct;

public record CreateGraphicsCardRequest : CreateRequestBase
{
    public required Memory Memory { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required int BusWidth { get; init; }
    public required int CudaCores { get; init; }
    public required int DirectXSupport { get; init; }
    public required int Tdp { get; init; }
}

public class CreateGraphicsCardRequestHandler(
    IProductRepository<GraphicsCard> productRepository,
    IFileService<GraphicsCard> fileService) : CreateProductRequestHandlerBase<CreateGraphicsCardRequest, GraphicsCard>(productRepository, fileService)
{
    protected override GraphicsCard CreateProduct(CreateGraphicsCardRequest request, string imagePath)
    {
        return new GraphicsCard
        {
            BrandId = request.BrandId,
            DiscountPercentage = request.DiscountPercentage,
            Memory = request.Memory,
            ClockSpeed = request.ClockSpeed,
            BusWidth = request.BusWidth,
            CudaCores = request.CudaCores,
            DirectXSupport = request.DirectXSupport,
            Tdp = request.Tdp,
            ModelName = request.ModelName,
            ImagePath = imagePath,
            InitialPrice = request.InitialPrice,
            Quantity = request.Quantity
        };
    }
}