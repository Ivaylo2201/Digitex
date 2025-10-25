using Microsoft.AspNetCore.Diagnostics;

namespace Backend.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static void UseGlobalExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(new
                {
                    context.Features.Get<IExceptionHandlerPathFeature>()?.Error.Message
                });
            });
        });
    }
}