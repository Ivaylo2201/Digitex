using Newtonsoft.Json;

namespace Backend.Application.Dtos.Chatbot;

public record ChatbotRequest
{
    [JsonProperty("message")]
    public required string Message { get; init; }
}