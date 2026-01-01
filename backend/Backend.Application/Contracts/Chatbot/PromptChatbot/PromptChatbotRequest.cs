namespace Backend.Application.Contracts.Chatbot.PromptChatbot;

public record PromptChatbotRequest
{
    public required IReadOnlyList<Message> Messages { get; init; }
}