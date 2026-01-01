namespace Backend.Application.Contracts.Chatbot;

public record ChatbotRequest
{
    public required string Message { get; init; }
}