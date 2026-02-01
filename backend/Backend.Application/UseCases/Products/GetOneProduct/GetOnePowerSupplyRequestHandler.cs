using Backend.Application.DTOs.Products.PowerSupply;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetOneProduct;

public record GetOnePowerSupplyRequest : GetOneProductRequestBase<PowerSupplyDto>;

public class GetOnePowerSupplyRequestHandler(
    IProductRepository<PowerSupply> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : GetOneProductRequestHandlerBase<GetOnePowerSupplyRequest, PowerSupply, PowerSupplyDto>(productRepository, exchangeRepository, currencyService);