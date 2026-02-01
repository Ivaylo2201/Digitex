using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.DeleteProduct;

public record DeletePowerSupplyRequestBase : DeleteRequestBase;

public class DeletePowerSupplyRequestHandler(IProductRepository<PowerSupply> productRepository)
    : DeleteProductRequestHandlerBase<DeletePowerSupplyRequestBase, PowerSupply>(productRepository);