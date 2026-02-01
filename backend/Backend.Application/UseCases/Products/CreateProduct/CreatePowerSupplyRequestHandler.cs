using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.CreateProduct;

public record CreatePowerSupplyRequest : CreateRequestBase
{
    public required int Wattage { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required int EfficiencyPercentage { get; init; }
    public required Modularity Modularity { get; init; }
}

public class CreatePowerSupplyRequestHandler(
    IProductRepository<PowerSupply> productRepository,
    IFileService<PowerSupply> fileService) 
    : CreateProductRequestHandlerBase<CreatePowerSupplyRequest, PowerSupply>(productRepository, fileService)
{
    protected override PowerSupply CreateProduct(CreatePowerSupplyRequest request, string imagePath)
    {
        return new PowerSupply
        {
            BrandId = request.BrandId,
            DiscountPercentage = request.DiscountPercentage,
            Wattage = request.Wattage,
            FormFactor = request.FormFactor,
            EfficiencyPercentage = request.EfficiencyPercentage,
            Modularity = request.Modularity,
            ModelName = request.ModelName,
            ImagePath = imagePath,
            InitialPrice = request.InitialPrice,
            Quantity = request.Quantity
        };
    }
}