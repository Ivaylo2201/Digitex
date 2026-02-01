using Backend.Domain.Interfaces.Repositories;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Application.UseCases.Products.DeleteProduct;

public record DeleteMonitorRequestBase : DeleteRequestBase;

public class DeleteMonitorRequestHandler(IProductRepository<Monitor> productRepository)
    : DeleteProductRequestHandlerBase<DeleteMonitorRequestBase, Monitor>(productRepository);