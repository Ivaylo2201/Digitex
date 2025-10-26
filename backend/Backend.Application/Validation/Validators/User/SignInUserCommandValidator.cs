using Backend.Application.CQRS.Entities.User.Commands;
using FluentValidation;

namespace Backend.Application.Validation.Validators.User;

public class SignInUserCommandValidator : AbstractValidator<SignInUserCommand>
{
    private const int UsernameMinLength = 5;
    private const int UsernameMaxLength = 25;
    private const int PasswordMinLength = 5;
    private const string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d).+$";

    public SignInUserCommandValidator()
    {
        RuleFor(c => c.Dto.Username)
            .NotEmpty().WithMessage("Username must be provided.")
            .Length(UsernameMinLength, UsernameMaxLength).WithMessage($"Username must be between {UsernameMinLength} and {UsernameMaxLength} characters.");

        RuleFor(c => c.Dto.Password)
            .NotEmpty().WithMessage("Password must be provided.")
            .MinimumLength(PasswordMinLength).WithMessage($"Password must be at least {PasswordMinLength} characters long.")
            .Matches(PasswordRegex).WithMessage("Password must contain both letters and numbers.")
            .Must((c, password) => !password.Contains(c.Dto.Username)).WithMessage("Password must not contain username.");
    }
}