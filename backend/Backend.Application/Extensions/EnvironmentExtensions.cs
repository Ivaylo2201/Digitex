using Backend.Domain.Exceptions;

namespace Backend.Application.Extensions;

public static class EnvironmentExtensions
{
    public static string GetRequiredEnvironmentVariable(this string variableName)
    {
        var variable = Environment.GetEnvironmentVariable(variableName);
        return variable ?? throw new ImproperlyConfiguredException(variableName);
    }
}