using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.UpdateProduct;

public record UpdatePowerSupplyRequest : UpdateRequestBase
{
    public required int Wattage { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required int EfficiencyPercentage { get; init; }
    public required Modularity Modularity { get; init; }
}

public class UpdatePowerSupplyRequestHandler(
    IProductRepository<PowerSupply> productRepository,
    IFileService<PowerSupply> fileService)
    : UpdateProductRequestHandlerBase<UpdatePowerSupplyRequest, PowerSupply>(productRepository, fileService)
{
    protected override PowerSupply CreateProduct(UpdatePowerSupplyRequest request, string imagePath)
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
            InitialPrice = request.Price,
            Quantity = request.Quantity
        };
    }
}