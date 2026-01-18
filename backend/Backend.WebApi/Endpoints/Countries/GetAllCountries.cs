using Backend.Application.DTOs;
using Backend.Application.UseCases.Countries.GetAllCountries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Countries;

public class GetAllCountries : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/", HandleAsync);
    
    private static async Task<Ok<IEnumerable<CountryDto>>> HandleAsync(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllCountriesRequest(), cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}