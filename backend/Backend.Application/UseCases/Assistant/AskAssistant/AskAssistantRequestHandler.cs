using System.Net;
using Backend.Application.Extensions;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Backend.Application.UseCases.Assistant.AskAssistant;

public class AskAssistantRequestHandler(
    ILogger<AskAssistantRequestHandler> logger,
    IAssistantClient assistantClient) : IRequestHandler<AskAssistantRequest, Result<AskAssistantResponse>>
{
    private const string Source = nameof(AskAssistantRequestHandler);
    
    public async Task<Result<AskAssistantResponse>> Handle(AskAssistantRequest request, CancellationToken cancellationToken)
    {
        var context = string.Join("\n", request.Messages.Select(message => $"{message.Sender}: {message.Content}"));
        
        try
        {
            var apiFreeLlmResponse = await assistantClient.AskAsync(context, cancellationToken);
            
            logger.LogInformation("[{Source}]: AI responded with {Response}.", Source, apiFreeLlmResponse.Response);
            return Result<AskAssistantResponse>.Success(HttpStatusCode.OK, new AskAssistantResponse
            {
                Response = apiFreeLlmResponse.Response
            });
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "processing chatbot request");
            return Result<AskAssistantResponse>.Success(HttpStatusCode.InternalServerError, new AskAssistantResponse
            {
                Response = "Something went wrong."
            });
        }
    }
}