using Backend.Domain.Enums;

namespace Backend.Application.Dtos.Accounts;

public record CompleteAccountVerificationResponse(string Token, Role Role);