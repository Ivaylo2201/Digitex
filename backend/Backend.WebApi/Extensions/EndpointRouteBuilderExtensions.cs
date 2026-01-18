using Backend.Domain.Extensions;

namespace Backend.WebApi.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static RouteGroupBuilder MapGroupWithTags(this IEndpointRouteBuilder builder, string groupName)
        => builder
            .MapGroup(groupName.ToLower())
            .WithTags(groupName.ToCapitalized());
}