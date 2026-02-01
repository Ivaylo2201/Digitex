using Backend.Application.DTOs.Products.Monitor;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Interfaces.Repositories;
using Monitor = Backend.Domain.Entities.Monitor;

namespace Backend.Application.UseCases.Products.GetOneProduct;

public record GetOneMonitorRequest : GetOneProductRequestBase<MonitorDto>;

public class GetOneMonitorRequestHandler(
    IProductRepository<Monitor> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : GetOneProductRequestHandlerBase<GetOneMonitorRequest, Monitor, MonitorDto>(productRepository, exchangeRepository, currencyService);
    