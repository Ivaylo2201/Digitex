using Backend.Domain.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.Extensions;

public static class ConfigurationExtensions
{
    public static string GetFromConfiguration(this IConfiguration configuration, string variableName)
    {
        var variable = configuration[variableName];
        return string.IsNullOrEmpty(variable) ? throw new ImproperlyConfiguredException($"{variableName} is missing in IConfiguration.") : variable;
    }
}