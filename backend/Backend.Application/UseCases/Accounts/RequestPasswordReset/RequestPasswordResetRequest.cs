using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Accounts.RequestPasswordReset;

public record RequestPasswordResetRequest : IRequest<Result<RequestPasswordResetResponse>>
{
    public required string Email { get; init; }
}