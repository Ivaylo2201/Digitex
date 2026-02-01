using Backend.Application.DTOs;
using Backend.Application.UseCases.Brands.GetAllBrands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<BrandDto>>> GetAllBrandsAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllBrandsRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}