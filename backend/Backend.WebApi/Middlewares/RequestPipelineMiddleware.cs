using System.Diagnostics;
using System.Reflection;

namespace Backend.WebApi.Middlewares;

public class RequestPipelineMiddleware(ILogger<RequestPipelineMiddleware> logger, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var source = Assembly.GetEntryAssembly()?.GetName().Name;
        var method = context.Request.Method;
        var path = context.Request.Path;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Executing {Method} {Endpoint}...", source, method, path);
        await next(context);
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {Method} {Endpoint} executed in {Duration}ms.", source, method, path, stopwatch.ElapsedMilliseconds);
    }
}