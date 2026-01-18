namespace Backend.Application.UseCases.Assistant.AskAssistant;

public record AskAssistantResponse
{
    public required string Response { get; init; }
}