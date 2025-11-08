using Backend.Application.DTOs.GraphicCards;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Services.Base;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services.Entities;

public class GraphicCardService(
    ILogger<GraphicCardService> logger,
    IProductRepository<GraphicCard> graphicCardRepository) : ProductServiceBase<GraphicCard, GraphicCardDto>(logger, graphicCardRepository);