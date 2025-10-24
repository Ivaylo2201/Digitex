namespace Backend.Application.DTOs;

public record CpuDto
{
    public required Guid Id { get; init; }
    public required string Brand { get; init; }
}