namespace Backend.Application.Contracts.Chatbot;

public record Message
{
    public required string Sender { get; init; }
    public required string Content { get; init; }
}