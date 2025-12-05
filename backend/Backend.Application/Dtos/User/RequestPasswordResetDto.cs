namespace Backend.Application.Dtos.User;

public class RequestPasswordResetDto
{
    public required string Email { get; init; }
}