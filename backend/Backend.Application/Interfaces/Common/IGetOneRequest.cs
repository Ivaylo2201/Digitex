using Backend.Domain.Enums;

namespace Backend.Application.Interfaces.Common;

public interface IGetOneRequest
{
    Guid Id { get; init; }
    CurrencyIsoCode Currency { get; init; }
}