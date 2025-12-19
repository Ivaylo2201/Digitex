using System.Text;
using Backend.Application.Dtos.Chatbot;
using Backend.Infrastructure.Http.Interfaces;
using Newtonsoft.Json;

namespace Backend.Infrastructure.Http;

public class ChatbotClient(HttpClient httpClient) : IChatbotClient
{
    public async Task<ChatbotResponse> PromptChatbotAsync(ChatbotRequest chatbotRequest, CancellationToken stoppingToken = default)
    {
        var requestBody = new StringContent(JsonConvert.SerializeObject(chatbotRequest), Encoding.UTF8, Constants.ApplicationJson);
        var response = await httpClient.PostAsync(string.Empty, requestBody, stoppingToken);
        response.EnsureSuccessStatusCode();
        
        var chatbotResponse = JsonConvert.DeserializeObject<ChatbotResponse>(await response.Content.ReadAsStringAsync(stoppingToken));
        return chatbotResponse ?? throw new JsonException("Could not deserialize response into ChatbotResponse.");
    }
}