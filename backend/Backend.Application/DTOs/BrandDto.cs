namespace Backend.Application.DTOs;

public record BrandDto
{
    public required int Id { get; init; }
    public required string BrandName { get; init; }
}