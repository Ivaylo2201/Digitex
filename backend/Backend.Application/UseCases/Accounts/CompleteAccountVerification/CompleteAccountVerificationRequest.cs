using Backend.Domain.Common;
using MediatR;

namespace Backend.Application.UseCases.Accounts.CompleteAccountVerification;

public record CompleteAccountVerificationRequest : IRequest<Result<CompleteAccountVerificationResponse>>
{
    public required string Token { get; init; }
}