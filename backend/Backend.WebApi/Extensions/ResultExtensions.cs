using Backend.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Extensions;

public static class ResultExtensions
{
    public static ProblemDetails ToProblemDetails<T>(this Result<T> result) => new()
    {
        Status = result.StatusCode,
        Title = result.ErrorMessage
    };
}