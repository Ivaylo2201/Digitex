using Backend.Application.DTOs.User;
using FluentValidation;

namespace Backend.Application.Validators;

public class SignInValidator : AbstractValidator<SignInDto>
{
    private const int UsernameMinLength = 5;
    private const int UsernameMaxLength = 25;
    private const int PasswordMinLength = 5;
    private const string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d).+$";

    public SignInValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username must be provided.")
            .Length(UsernameMinLength, UsernameMaxLength).WithMessage($"Username must be between {UsernameMinLength} and {UsernameMaxLength} characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password must be provided.")
            .MinimumLength(PasswordMinLength)
            .WithMessage($"Password must be at least {PasswordMinLength} characters long.")
            .Matches(PasswordRegex).WithMessage("Password must contain both letters and numbers.");
    }
}