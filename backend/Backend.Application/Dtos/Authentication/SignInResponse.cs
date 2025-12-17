using Backend.Domain.Enums;

namespace Backend.Application.Dtos.Authentication;

public record SignInResponse(string Token, Role Role);