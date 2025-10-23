using System.Diagnostics;
using System.Reflection;

namespace Backend.WebApi.Middlewares;

public class RequestDurationMiddleware(ILogger<RequestDurationMiddleware> logger, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        await next(context);

        stopwatch.Stop();
        
        logger.LogInformation(
            "[{Source}]: {Method} {Endpoint} executed in {Duration}ms",
            Assembly.GetEntryAssembly()?.GetName().Name,
            context.Request.Method,
            context.Request.Path, 
            stopwatch.ElapsedMilliseconds);
    }
}