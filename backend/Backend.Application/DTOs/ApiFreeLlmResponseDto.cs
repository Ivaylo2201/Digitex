using System.Text.Json.Serialization;

namespace Backend.Application.DTOs;

public class ApiFreeLlmResponseDto
{
    public bool Success { get; set; }
    [JsonPropertyName("response")]
    public string Response { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Tier { get; set; } = string.Empty;
}