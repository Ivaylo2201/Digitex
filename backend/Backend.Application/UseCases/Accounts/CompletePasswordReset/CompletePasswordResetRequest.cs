using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Accounts.CompletePasswordReset;

public record CompletePasswordResetRequest : IRequest<Result<CompletePasswordResetResponse>>
{
    public required string Token { get; init; }
    public required string NewPassword { get; init; }
}