using Backend.Application.Interfaces.Services;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.ValueObjects;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Application.UseCases.Products.UpdateProduct;

public record UpdateMonitorRequest : UpdateRequestBase
{
    public required double DisplayDiagonal { get; init; }
    public required int RefreshRate { get; init; }
    public required double Latency { get; init; }
    public required Matrix Matrix { get; init; }
    public required Resolution Resolution { get; init; }
    public required double PixelSize { get; init; }
    public required int Brightness { get; init; }
    public required int ColorSpectre { get; init; }
}

public class UpdateMonitorRequestHandler(
    IProductRepository<Monitor> productRepository,
    IFileService<Monitor> fileService)
    : UpdateProductRequestHandlerBase<UpdateMonitorRequest, Monitor>(productRepository, fileService)
{
    protected override Monitor CreateProduct(UpdateMonitorRequest request, string imagePath)
    {
        return new Monitor
        {
            BrandId = request.BrandId,
            DiscountPercentage = request.DiscountPercentage,
            DisplayDiagonal = request.DisplayDiagonal,
            RefreshRate = request.RefreshRate,
            Latency = request.Latency,
            Matrix = request.Matrix,
            Resolution = request.Resolution,
            PixelSize = request.PixelSize,
            Brightness = request.Brightness,
            ColorSpectre = request.ColorSpectre,
            ModelName = request.ModelName,
            ImagePath = imagePath,
            InitialPrice = request.InitialPrice,
            Quantity = request.Quantity
        };
    }
}