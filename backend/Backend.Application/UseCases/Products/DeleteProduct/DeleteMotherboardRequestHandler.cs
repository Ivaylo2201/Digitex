using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.DeleteProduct;

public record DeleteMotherboardRequestBase : DeleteRequestBase;

public class DeleteMotherboardRequestHandler(IProductRepository<Motherboard> productRepository)
    : DeleteProductRequestHandlerBase<DeleteMotherboardRequestBase, Motherboard>(productRepository);