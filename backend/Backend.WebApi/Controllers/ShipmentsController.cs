using Backend.Application.DTOs;
using Backend.Application.UseCases.Shipments.GetAllShipments;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<ShipmentDto>>> GetAllShipmentsAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllShipmentsRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}