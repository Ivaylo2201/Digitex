using System.Net; 
using Backend.Application.Extensions;
using Backend.Application.Interfaces.Http;
using Backend.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Backend.Application.UseCases.Assistant.AskAssistant;

public class AskAssistantRequestHandler(
    ILogger<AskAssistantRequestHandler> logger,
    IAssistantClient assistantClient) : IRequestHandler<AskAssistantRequest, Result<AskAssistantResponse>>
{
    private const string Source = nameof(AskAssistantRequestHandler);
    
    public async Task<Result<AskAssistantResponse>> Handle(AskAssistantRequest request, CancellationToken cancellationToken)
    {
        using (LogContext.PushProperty("Source", Source))
        {
            logger.LogRequestProcessingStart(nameof(AskAssistantRequest));
            
            logger.LogDebug("Building message context...");
            var context = string.Join("\n", request.Messages.Select(message => $"{message.Sender}: {message.Content}"));

            try
            {
                logger.LogDebug("Sending request to ApiFreeLlm...");
                var apiFreeLlmResponse = await assistantClient.AskAsync(context, cancellationToken);

                if (apiFreeLlmResponse is null)
                {
                    logger.LogDebug("Could not deserialize response into AskAssistantResponse.");
                    return Result<AskAssistantResponse>.Failure(HttpStatusCode.InternalServerError);
                }
                
                return Result<AskAssistantResponse>.Success(HttpStatusCode.OK, new AskAssistantResponse
                {
                    Response = apiFreeLlmResponse.Response
                });
            }
            catch (Exception)
            {
                return Result<AskAssistantResponse>.Success(HttpStatusCode.ServiceUnavailable, new AskAssistantResponse
                {
                    Response = "ApiFreeLlm is currently unavailable."
                });
            }
        }
    }
}