using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Backend.Application.Extensions;

public static class LoggerExtensions
{
    public static void LogQueryExecutionStart(this ILogger logger, string source, string queryName, string details = "")
    {
        logger.LogInformation("[{Source}]: Executing {QueryName}{Details}...", source, queryName, details);
    }

    public static void LogQueryExecutionDuration(this ILogger logger, string source, string queryName, Stopwatch stopwatch)
    {
        stopwatch.Stop();
        logger.LogInformation("[{Source}]: {QueryName} executed in {Duration}ms.", source, queryName, stopwatch.ElapsedMilliseconds);
    }
}