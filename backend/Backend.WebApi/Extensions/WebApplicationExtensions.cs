using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace Backend.WebApi.Extensions;

public static class WebApplicationExtensions
{
    private const string ContentType = "application/json";
    private const string ErrorMessageFallback = "An error occurred.";
    
    public static void UseGlobalExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.ContentType = ContentType;

                var error = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;

                if (error is ValidationException exception)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    var errors = exception.Errors.Select(failure => new
                    {
                        Property = failure.PropertyName.Split('.').Last(),
                        Message = failure.ErrorMessage
                    });

                    await context.Response.WriteAsJsonAsync(new { errors });
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsJsonAsync(new { Message = error?.Message ?? ErrorMessageFallback });
                }
            });
        });
    }
}