using Backend.Application.DTOs;
using Backend.Application.UseCases.Shipments.GetAllShipments;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Shipments;

public class GetAllShipments : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/", HandleAsync);
    
    private static async Task<Ok<IEnumerable<ShipmentDto>>> HandleAsync(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllShipmentsRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}