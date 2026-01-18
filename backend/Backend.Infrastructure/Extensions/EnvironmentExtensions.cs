using Backend.Domain.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Backend.Infrastructure.Extensions;

public static class EnvironmentExtensions
{
    public static string GetRequiredEnvironmentVariable(this string variableName)
    {
        var variable = Environment.GetEnvironmentVariable(variableName);
        return variable ?? throw new ImproperlyConfiguredException(variableName);
    }
    
    public static string GetRequiredAppSettingsVariable(this IConfiguration configuration, string variablePath)
    {
        var variable = configuration[variablePath];
        return variable ?? throw new ImproperlyConfiguredException(variablePath.Split(':').Last());
    }
}