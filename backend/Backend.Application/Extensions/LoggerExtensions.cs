using Microsoft.Extensions.Logging;

namespace Backend.Application.Extensions;

public static class LoggerExtensions
{
    public static void LogException(this ILogger logger, string source, Exception ex, string action)
    {
        var exceptionMessage = ex.InnerException?.Message ?? ex.Message;
        var exceptionType = ex.InnerException?.GetType().Name ?? ex.GetType().Name;
        
        logger.LogError("[{Source}]: An {ExceptionType} occurred while {Action}. Exception message: {ExceptionMessage}", source, exceptionType, action, exceptionMessage);
    }
}