using Backend.Application.DTOs;

namespace Backend.Application.Interfaces;

public interface IAssistantClient
{
    Task<ApiFreeLlmResponse> AskAsync(string message, CancellationToken cancellationToken);
}