using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.DeleteProduct;

public record DeleteGraphicsCardRequestBase : DeleteRequestBase;

public class DeleteGraphicsCardRequestHandler(IProductRepository<GraphicsCard> productRepository)
    : DeleteProductRequestHandlerBase<DeleteGraphicsCardRequestBase, GraphicsCard>(productRepository);