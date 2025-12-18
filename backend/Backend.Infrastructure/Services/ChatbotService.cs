using System.Text;
using Backend.Application.Dtos.Chatbot;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Backend.Infrastructure.Services;

public class ChatbotService(ILogger<ChatbotService> logger, HttpClient httpClient) : IChatbotService
{
    private const string Source = nameof(ChatbotService);
    
    public async Task<Result<string>> PromptChatbotAsync(PromptChatbotRequest promptChatbotRequest, CancellationToken stoppingToken = default)
    {
        var prompt = string.Join("\n", promptChatbotRequest.Messages.Select(message => $"{message.Sender}: {message.Content}"));
        var chatbotRequest = JsonConvert.SerializeObject(new ChatbotRequest { Message = prompt });
        var requestBody = new StringContent(chatbotRequest, Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync("CHATBOT_ENDPOINT".GetRequiredEnvironmentVariable(), requestBody, stoppingToken);
            var chatbotResponse = JsonConvert.DeserializeObject<ChatbotResponse>(await response.Content.ReadAsStringAsync(stoppingToken));

            if (chatbotResponse is null)
                throw new JsonException("Could not deserialize response into ChatbotResponse.");
            
            return Result<string>.Success(StatusCodes.Status200OK, chatbotResponse.Response);
        }
        catch (Exception ex)
        {
            logger.LogException(Source, ex, "processing chatbot request");
            return Result<string>.Success(StatusCodes.Status400BadRequest, "Something went wrong.");
        }
    }
}