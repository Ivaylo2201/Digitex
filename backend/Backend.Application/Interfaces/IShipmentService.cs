using Backend.Application.Dtos.Shipment;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces.Services;

public interface IShipmentService
{
    Task<Result<List<ShipmentDto>>> ListAllAsync(CancellationToken stoppingToken = default);
}