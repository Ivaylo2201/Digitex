using Backend.Application.Contracts.Shipment.ListShipments;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface IShipmentService
{
    Task<Result<List<ShipmentProjection>>> ListAllAsync(CancellationToken stoppingToken = default);
}