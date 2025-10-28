using FluentValidation.Results;

namespace Backend.Infrastructure.Extensions;

public static class ValidationFailureExtensions
{
    public static object ToObject(this List<ValidationFailure> failures)
    {
        return new
        {
            Errors = failures.Select(failure => new { failure.PropertyName, failure.ErrorMessage })
        };
    }
}