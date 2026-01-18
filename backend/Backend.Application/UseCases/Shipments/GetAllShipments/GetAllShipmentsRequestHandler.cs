using System.Net;
using Backend.Application.DTOs;
using Backend.Domain.Common;
using Backend.Domain.Interfaces;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Shipments.GetAllShipments;

public class GetAllShipmentsRequestHandler(
    ILogger<GetAllShipmentsRequestHandler> logger,
    IShipmentRepository shipmentRepository) : IRequestHandler<GetAllShipmentsRequest, Result<IEnumerable<ShipmentDto>>>
{
    public async Task<Result<IEnumerable<ShipmentDto>>> Handle(GetAllShipmentsRequest request, CancellationToken cancellationToken)
    {
        var shipments = await shipmentRepository.GetAllAsync(cancellationToken);
        return Result<IEnumerable<ShipmentDto>>.Success(HttpStatusCode.OK, shipments.Adapt<IEnumerable<ShipmentDto>>());
    }
}