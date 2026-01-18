using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Currencies.GetAllCurrencies;

public record GetAllCurrenciesRequest : IRequest<Result<IEnumerable<CurrencyDto>>>;