using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Shipments.GetAllShipments;

public record GetAllShipmentsRequest : IRequest<Result<IEnumerable<ShipmentDto>>>;