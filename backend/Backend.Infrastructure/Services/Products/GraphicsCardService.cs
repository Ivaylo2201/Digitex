using Backend.Application.Dtos.Products;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Products;

public class GraphicsCardService(ILogger<GraphicsCardService> logger, IProductRepository<GraphicsCard> graphicCardRepository)
    : ProductServiceBase<GraphicsCard, GraphicsCardDto>(logger, graphicCardRepository);