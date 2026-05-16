using System.Text;
using System.Text.Json;
using Backend.Application.DTOs;
using Backend.Application.Interfaces.Http;
using Backend.Domain.Settings;
using Microsoft.Extensions.Options;

namespace Backend.Infrastructure.Http;

public class AssistantClient(HttpClient httpClient, IOptions<EnvSettings> options) : IAssistantClient
{
    public async Task<ApiFreeLlmResponseDto?> AskAsync(string message, CancellationToken cancellationToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, string.Empty)
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { message }),
                Encoding.UTF8,
                HttpConstants.ApplicationJson)
        };

        request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", options.Value.Assistant.ApiKey);

        var httpResponseMessage = await httpClient.SendAsync(request, cancellationToken);
        
        // if (!httpResponseMessage.IsSuccessStatusCode)
        //     throw new HttpRequestException("Non-success status code returned from ApiFreeLlm.");
        
        var content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<ApiFreeLlmResponseDto>(content);
    }
}