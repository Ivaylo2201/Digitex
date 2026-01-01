namespace Backend.Application.Contracts.Chatbot.PromptChatbot;

public record PromptChatbotResponse
{
    public string? Message { get; init; }
}