using Backend.Application.Dtos.Chatbot;

namespace Backend.Infrastructure.Http.Interfaces;

public interface IChatbotClient
{
    Task<ChatbotResponse> PromptChatbotAsync(ChatbotRequest chatbotRequest, CancellationToken cancellationToken = default);
}