using Backend.Application.Contracts.Shipment;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.Services;

public class ShipmentService(IShipmentRepository shipmentRepository) : IShipmentService
{
    public async Task<Result<IReadOnlyList<ShipmentDto>>> GetShipmentsAsync(CancellationToken cancellationToken = default)
    {
        var shipments = await shipmentRepository.ListAllAsync(cancellationToken: cancellationToken);
        var projections = shipments.Adapt<IReadOnlyList<ShipmentDto>>();
        
        return Result<IReadOnlyList<ShipmentDto>>.Success(StatusCodes.Status200OK, projections);   
    }
}