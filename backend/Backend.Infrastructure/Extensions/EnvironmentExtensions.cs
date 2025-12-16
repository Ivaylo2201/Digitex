using Backend.Domain.Exceptions;

namespace Backend.Infrastructure.Extensions;

public static class EnvironmentExtensions
{
    public static string GetRequiredEnvironmentalVariable(this string variableName)
    {
        var variable = Environment.GetEnvironmentVariable(variableName);
        return string.IsNullOrEmpty(variable) ? throw new ImproperlyConfiguredException($"{variableName} missing in .env") : variable;
    }
}