using Backend.Application.UseCases.Assistant.AskAssistant;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssistantController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<Results<Ok<AskAssistantResponse>, InternalServerError<AskAssistantResponse>>> AskAsync([FromBody] AskAssistantRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return result.IsSuccess
            ? TypedResults.Ok(result.Value)
            : TypedResults.InternalServerError(result.Value);
    }
}