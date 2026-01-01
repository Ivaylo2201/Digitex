using Backend.Application.Contracts.Chatbot.PromptChatbot;
using Backend.Application.Interfaces;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatbotController(IChatbotService chatbotService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<PromptChatbotResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<PromptChatbotResponse>(StatusCodes.Status500InternalServerError)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> PromptChatbotAsync([FromBody] PromptChatbotRequest promptChatbotRequest, CancellationToken cancellationToken = default)
    {
        var result = await chatbotService.PromptChatbotAsync(promptChatbotRequest, cancellationToken);
        return StatusCode(result.StatusCode, new PromptChatbotResponse { Message = result.Value });
    }
}