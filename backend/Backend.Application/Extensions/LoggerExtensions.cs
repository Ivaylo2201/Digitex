using Microsoft.Extensions.Logging;

namespace Backend.Application.Extensions;

public static class LoggerExtensions
{
    extension(ILogger logger)
    {
        public void LogRequestProcessingStart(string request)
            => logger.LogInformation("Processing {Request}...", request);
    }
}