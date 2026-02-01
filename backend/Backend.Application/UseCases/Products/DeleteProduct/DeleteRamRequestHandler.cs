using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.DeleteProduct;

public record DeleteRamRequestBase : DeleteRequestBase;

public class DeleteRamRequestHandler(IProductRepository<Ram> productRepository)
    : DeleteProductRequestHandlerBase<DeleteRamRequestBase, Ram>(productRepository);