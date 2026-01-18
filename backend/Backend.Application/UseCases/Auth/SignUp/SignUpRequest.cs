using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Auth.SignUp;

public record SignUpRequest : IRequest<Result<SignUpResponse>>
{
    public required string Username { get; init; }
    public required string Email { get; init; }   
    public required string Password { get; init; }
    public required string PasswordConfirmation { get; init; }
}