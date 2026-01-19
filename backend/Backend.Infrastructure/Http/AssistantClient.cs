using System.Net;
using System.Text;
using System.Text.Json;
using Backend.Application.DTOs;
using Backend.Application.Interfaces.Http;

namespace Backend.Infrastructure.Http;

public class AssistantClient(HttpClient httpClient) : IAssistantClient
{
    public async Task<ApiFreeLlmResponseDto> AskAsync(string message, CancellationToken cancellationToken)
    {
        var requestBody = new StringContent(
            JsonSerializer.Serialize(new { message }),
            Encoding.UTF8,
            HttpConstants.ApplicationJson);
        
        var httpResponseMessage = await httpClient.PostAsync(string.Empty, requestBody, cancellationToken);
        
        if (httpResponseMessage.StatusCode is not HttpStatusCode.OK)
            throw new HttpRequestException("ApiFreeLlmClient received a non-success status code.");
        
        var content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        var apiFreeLlmResponse = JsonSerializer.Deserialize<ApiFreeLlmResponseDto>(content);
        
        return apiFreeLlmResponse ?? throw new JsonException("Could not deserialize response into AskAssistantResponse.");
    }
}