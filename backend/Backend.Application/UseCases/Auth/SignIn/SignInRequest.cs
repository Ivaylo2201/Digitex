using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Auth.SignIn;

public record SignInRequest : IRequest<Result<SignInResponse>>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}