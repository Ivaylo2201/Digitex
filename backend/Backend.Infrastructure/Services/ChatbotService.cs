using Backend.Application.Dtos.Chatbot;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Backend.Infrastructure.Http.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Backend.Infrastructure.Services;

public class ChatbotService(ILogger<ChatbotService> logger, IChatbotClient chatbotClient) : IChatbotService
{
    private const string Source = nameof(ChatbotService);
    
    public async Task<Result<string>> PromptChatbotAsync(PromptChatbotRequest promptChatbotRequest, CancellationToken stoppingToken = default)
    {
        logger.LogInformation("[{Source}]: Building context prompt with {MessageCount} messages...", Source, promptChatbotRequest.Messages.Count);
        var promptWithContext = string.Join("\n", promptChatbotRequest.Messages.Select(message => $"{message.Sender}: {message.Content}"));
        var chatbotRequest = new ChatbotRequest { Message = promptWithContext };
        
        try
        {
            logger.LogInformation("[{Source}]: Prompting AI endpoint...", Source);
            var chatbotResponse = await chatbotClient.PromptChatbotAsync(chatbotRequest, stoppingToken);
            
            logger.LogInformation("[{Source}]: AI responded with {Response}.", Source, chatbotResponse.Response);
            return Result<string>.Success(StatusCodes.Status200OK, chatbotResponse.Response);
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "processing chatbot request");
            return Result<string>.Success(StatusCodes.Status400BadRequest, "Something went wrong.");
        }
    }
}