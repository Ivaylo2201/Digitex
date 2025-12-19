using Backend.Application.Dtos.Chatbot;
using Backend.Application.Interfaces;
using Backend.Domain.Common;
using Backend.Infrastructure.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatbotController(IChatbotService chatbotService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<PromptChatbotResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ErrorObject>(StatusCodes.Status400BadRequest)]
    [Produces(Constants.ApplicationJson)]
    [Consumes(Constants.ApplicationJson)]
    public async Task<IActionResult> PromptChatbotAsync([FromBody] PromptChatbotRequest promptChatbotRequest, CancellationToken stoppingToken = default)
    {
        var result = await chatbotService.PromptChatbotAsync(promptChatbotRequest, stoppingToken);
        return StatusCode(result.StatusCode, result.IsSuccess ? new PromptChatbotResponse(result.Value) : result.ErrorObject);
    }
}