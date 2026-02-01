using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Enums;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.CreateProduct;

public record CreateMotherboardRequest : CreateRequestBase
{
    public required Socket Socket { get; init; }
    public required FormFactor FormFactor { get; init; }
    public required Chipset Chipset { get; init; }
    public required int RamSlots { get; init; }
    public required int PcieSlots { get; init; }
}

public class CreateMotherboardRequestHandler(
    IProductRepository<Motherboard> productRepository,
    IFileService<Motherboard> fileService) 
    : CreateProductRequestHandlerBase<CreateMotherboardRequest, Motherboard>(productRepository, fileService)
{
    protected override Motherboard CreateProduct(CreateMotherboardRequest request, string imagePath)
    {
        return new Motherboard
        {
            BrandId = request.BrandId,
            DiscountPercentage = request.DiscountPercentage,
            Socket = request.Socket,
            FormFactor = request.FormFactor,
            Chipset = request.Chipset,
            RamSlots = request.RamSlots,
            PcieSlots = request.PcieSlots,
            ModelName = request.ModelName,
            ImagePath = imagePath,
            InitialPrice = request.InitialPrice,
            Quantity = request.Quantity
        };
    }
}