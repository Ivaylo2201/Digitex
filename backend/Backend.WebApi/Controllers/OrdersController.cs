using Backend.Application.UseCases.Orders.GetUserOrders;
using Backend.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<Ok<GetUserOrdersResponse>> GetUserOrdersAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUserOrdersRequest().Authorize(HttpContext), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}