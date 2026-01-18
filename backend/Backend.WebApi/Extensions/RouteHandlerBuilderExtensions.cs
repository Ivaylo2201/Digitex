using Backend.WebApi.Filters;

namespace Backend.WebApi.Extensions;

public static class RouteHandlerBuilderExtensions
{
    public static RouteHandlerBuilder WithValidator<TRequest>(this RouteHandlerBuilder builder)
    {
        return builder
            .AddEndpointFilter<ValidationFilter<TRequest>>()
            .ProducesValidationProblem();
    }
}