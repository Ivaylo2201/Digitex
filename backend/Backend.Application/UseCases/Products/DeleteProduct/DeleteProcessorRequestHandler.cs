using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.DeleteProduct;

public record DeleteProcessorRequestBase : DeleteRequestBase;

public class DeleteProcessorRequestHandler(IProductRepository<Processor> productRepository)
    : DeleteProductRequestHandlerBase<DeleteProcessorRequestBase, Processor>(productRepository);
    