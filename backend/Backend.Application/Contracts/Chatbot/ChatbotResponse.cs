namespace Backend.Application.Contracts.Chatbot;

public record ChatbotResponse
{
    public required string Response { get; init; }
}