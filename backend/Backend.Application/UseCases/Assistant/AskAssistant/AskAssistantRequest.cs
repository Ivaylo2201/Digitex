using Backend.Application.DTOs;
using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Assistant.AskAssistant;

public record AskAssistantRequest : IRequest<Result<AskAssistantResponse>>
{
    public required IEnumerable<MessageDto> Messages { get; init; }
}