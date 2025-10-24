using System.Diagnostics;
using System.Reflection;

namespace Backend.WebApi.Middlewares;

public class RequestPipelineMiddleware(ILogger<RequestPipelineMiddleware> logger, RequestDelegate next)
{
    private readonly string _source = Assembly.GetEntryAssembly()?.GetName().Name ?? "Backend.WebApi";
    
    public async Task InvokeAsync(HttpContext context)
    {
        var method = context.Request.Method;
        var path = context.Request.Path;
        var stopwatch = Stopwatch.StartNew();
        
        logger.LogInformation("[{Source}]: Executing {Method} {Endpoint}...", _source, method, path);
        await next(context);
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {Method} {Endpoint} executed in {Duration}ms.", _source, method, path, stopwatch.ElapsedMilliseconds);
    }
}