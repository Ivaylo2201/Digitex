using Backend.Application.Dtos.User;
using FluentValidation;

namespace Backend.Application.Validators;

public class SignUpValidator : AbstractValidator<SignUpDto>
{
    private const int UsernameMinLength = 5;
    private const int UsernameMaxLength = 25;
    private const int PasswordMinLength = 5;
    private const string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d).+$";

    public SignUpValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username must be provided.")
            .Length(UsernameMinLength, UsernameMaxLength).WithMessage($"Username must be between {UsernameMinLength} and {UsernameMaxLength} characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password must be provided.")
            .MinimumLength(PasswordMinLength).WithMessage($"Password must be at least {PasswordMinLength} characters long.")
            .Matches(PasswordRegex).WithMessage("Password must contain both letters and numbers.")
            .Must((c, password) => !password.Contains(c.Username)).WithMessage("Password must not contain username.");

        RuleFor(x => x.PasswordConfirmation)
            .NotEmpty().WithMessage("PasswordConfirmation must be provided.")
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match.");
    }
}