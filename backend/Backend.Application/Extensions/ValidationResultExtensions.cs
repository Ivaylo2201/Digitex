using FluentValidation.Results;
using Serilog;

namespace Backend.Application.Extensions;

public static class ValidationResultExtensions
{
    public static string GetStringifiedErrors(this ValidationResult validationResult, string source)
    {
        var errors = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
        Log.Error("[{Source}]: Validation failed. Errors: {Errors}", source, errors);
        return errors;
    }
}