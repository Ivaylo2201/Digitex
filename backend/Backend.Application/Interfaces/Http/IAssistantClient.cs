using Backend.Application.DTOs;

namespace Backend.Application.Interfaces.Http;

public interface IAssistantClient
{
    Task<ApiFreeLlmResponseDto> AskAsync(string message, CancellationToken cancellationToken);
}