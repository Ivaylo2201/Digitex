using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.DeleteProduct;

public record DeleteSsdRequestBase : DeleteRequestBase;

public class DeleteSsdRequestHandler(IProductRepository<Ssd> productRepository)
    : DeleteProductRequestHandlerBase<DeleteSsdRequestBase, Ssd>(productRepository);