using Backend.Application.Contracts.Chatbot.PromptChatbot;
using Backend.Domain.Common;

namespace Backend.Application.Interfaces;

public interface IChatbotService
{
    Task<Result<string>> PromptChatbotAsync(PromptChatbotRequest promptChatbotRequest, CancellationToken cancellationToken = default);
}