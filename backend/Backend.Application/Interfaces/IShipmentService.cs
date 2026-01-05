using Backend.Application.Contracts.Shipment;
using Backend.Domain.Common;
using Backend.Domain.Enums;

namespace Backend.Application.Interfaces;

public interface IShipmentService
{
    Task<Result<IReadOnlyList<ShipmentDto>>> GetShipmentsAsync(CurrencyIsoCode currencyIsoCode, CancellationToken cancellationToken = default);
}