using Backend.Application.DTOs.Products.Processor;
using Backend.Application.Interfaces.Services;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;

namespace Backend.Application.UseCases.Products.GetOneProduct;

public record GetOneProcessorRequest : GetOneProductRequestBase<ProcessorDto>;

public class GetOneProcessorRequestHandler(
    IProductRepository<Processor> productRepository,
    IExchangeRepository exchangeRepository,
    ICurrencyService currencyService) : GetOneProductRequestHandlerBase<GetOneProcessorRequest, Processor, ProcessorDto>(productRepository, exchangeRepository, currencyService);
