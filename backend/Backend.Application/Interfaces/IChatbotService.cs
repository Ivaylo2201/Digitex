using Backend.Application.Dtos.Chatbot;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface IChatbotService
{
    Task<Result<string>> PromptChatbotAsync(PromptChatbotRequest promptChatbotRequest, CancellationToken cancellationToken = default);
}