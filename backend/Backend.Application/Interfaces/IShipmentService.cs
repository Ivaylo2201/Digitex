using Backend.Application.Contracts.Shipment;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface IShipmentService
{
    Task<Result<IReadOnlyList<ShipmentDto>>> GetShipmentsAsync(CancellationToken cancellationToken = default);
}