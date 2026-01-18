using Backend.Application.DTOs;
using Backend.Application.UseCases.Cities.GetAllCitiesByCountry;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Endpoints.Cities;

public class GetCitiesByCountry : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app
        .MapGet("/", HandleAsync);

    private static async Task<Ok<IEnumerable<CityDto>>> HandleAsync(
        [FromQuery] int countryId,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllCitiesByCountryRequest { CountryId = countryId }, cancellationToken);
        return TypedResults.Ok(result.Value);
    }
}