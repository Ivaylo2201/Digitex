using Backend.Application.DTOs.Products.Ssd;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetOneProduct;

public record GetOneSsdRequest : GetOneProductRequestBase<SsdDto>;

public class GetOneSsdRequestHandler(
    IProductRepository<Ssd> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : GetOneProductRequestHandlerBase<GetOneSsdRequest, Ssd, SsdDto>(productRepository, exchangeRepository, currencyService);