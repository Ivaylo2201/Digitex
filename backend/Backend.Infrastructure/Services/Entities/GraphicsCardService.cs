using Backend.Application.DTOs.GraphicsCards;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class GraphicsCardService(
    ILogger<GraphicsCardService> logger,
    IProductRepository<GraphicsCard> graphicCardRepository) : ProductServiceBase<GraphicsCard, GraphicsCardDto>(logger, graphicCardRepository);