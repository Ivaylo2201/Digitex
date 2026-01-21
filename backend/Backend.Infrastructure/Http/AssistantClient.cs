using System.Text;
using System.Text.Json;
using Backend.Application.DTOs;
using Backend.Application.Interfaces.Http;

namespace Backend.Infrastructure.Http;

public class AssistantClient(HttpClient httpClient) : IAssistantClient
{
    public async Task<ApiFreeLlmResponseDto?> AskAsync(string message, CancellationToken cancellationToken)
    {
        var requestBody = new StringContent(
            JsonSerializer.Serialize(new { message }),
            Encoding.UTF8,
            HttpConstants.ApplicationJson);
        
        var httpResponseMessage = await httpClient.PostAsync(string.Empty, requestBody, cancellationToken);
        
        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new HttpRequestException("Non-success status code returned from ApiFreeLlm.");
        
        var content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<ApiFreeLlmResponseDto>(content);
    }
}