using Backend.Application.DTOs.Products.Ram;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetOneProduct;

public record GetOneRamRequest : GetOneProductRequestBase<RamDto>;

public class GetOneRamRequestHandler(
    IProductRepository<Ram> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : GetOneProductRequestHandlerBase<GetOneRamRequest, Ram, RamDto>(productRepository, exchangeRepository, currencyService);