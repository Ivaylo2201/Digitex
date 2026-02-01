using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;
using Backend.Domain.ValueObjects;

namespace Backend.Application.UseCases.Products.UpdateProduct;

public record UpdateProcessorRequest : UpdateRequestBase
{
    public required int Cores { get; init; }
    public required int Threads { get; init; }
    public required ClockSpeed ClockSpeed { get; init; }
    public required Socket Socket { get; init; } 
    public required int Tdp { get; init; }
}

public class UpdateProcessorRequestHandler(
    IProductRepository<Processor> productRepository,
    IFileService<Processor> fileService)
    : UpdateProductRequestHandlerBase<UpdateProcessorRequest, Processor>(productRepository, fileService)
{
    protected override Processor CreateProduct(UpdateProcessorRequest request, string imagePath)
    {
        return new Processor
        {
            BrandId = request.BrandId,
            DiscountPercentage = request.DiscountPercentage,
            Cores = request.Cores,
            Threads = request.Threads,
            ClockSpeed = request.ClockSpeed,
            Socket = request.Socket,
            Tdp = request.Tdp,
            ModelName = request.ModelName,
            ImagePath = imagePath,
            InitialPrice = request.InitialPrice,
            Quantity = request.Quantity
        };
    }
}