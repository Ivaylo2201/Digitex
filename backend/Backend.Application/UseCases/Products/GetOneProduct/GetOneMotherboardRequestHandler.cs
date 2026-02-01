using Backend.Application.DTOs.Products.Motherboard;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetOneProduct;

public record GetOneMotherboardRequest : GetOneProductRequestBase<MotherboardDto>;

public class GetOneMotherboardRequestHandler(
    IProductRepository<Motherboard> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : GetOneProductRequestHandlerBase<GetOneMotherboardRequest, Motherboard, MotherboardDto>(productRepository, exchangeRepository, currencyService);
    