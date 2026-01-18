using System.Reflection;
using Backend.WebApi.Endpoints;

namespace Backend.WebApi.Extensions;

public static class EndpointsConfigurationExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        var baseGroup = app.MapGroup("api");

        var groups = new Dictionary<string, IEndpointRouteBuilder>();

        Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !type.IsAbstract && typeof(IEndpoint).IsAssignableFrom(type))
            .ToList()
            .ForEach(endpoint =>
            {
                var groupName = endpoint.Namespace?.Split('.').Last() ?? string.Empty;

                if (!groups.TryGetValue(groupName, out var group))
                {
                    group = baseGroup.MapGroupWithTags(groupName);
                    groups[groupName] = group;
                }

                var map = endpoint.GetMethod("Map", BindingFlags.Public | BindingFlags.Static);
                map?.Invoke(null, [group]);
            });
    }
}