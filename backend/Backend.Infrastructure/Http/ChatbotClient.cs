using System.Net;
using System.Text;
using Backend.Application.Contracts.Chatbot;
using Backend.Infrastructure.Http.Interfaces;
using Newtonsoft.Json;

namespace Backend.Infrastructure.Http;

public class ChatbotClient(HttpClient httpClient) : IChatbotClient
{
    public async Task<ChatbotResponse> PromptChatbotAsync(ChatbotRequest chatbotRequest, CancellationToken stoppingToken = default)
    {
        var requestBody = new StringContent(JsonConvert.SerializeObject(chatbotRequest), Encoding.UTF8, Constants.ApplicationJson);
        var response = await httpClient.PostAsync(string.Empty, requestBody, stoppingToken);
        var content = await response.Content.ReadAsStringAsync(stoppingToken);

        if (response.StatusCode is not HttpStatusCode.OK)
            throw new HttpRequestException(content);
        
        var chatbotResponse = JsonConvert.DeserializeObject<ChatbotResponse>(content);
        return chatbotResponse ?? throw new JsonException("Could not deserialize response into ChatbotResponse.");
    }
}