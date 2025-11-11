using Backend.Application.Dtos.User;
using FluentValidation;

namespace Backend.Application.Validators;

public class SignInValidator : AbstractValidator<SignInDto>
{
    private const int PasswordMinLength = 5;
    private const string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d).+$";

    public SignInValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email must be provided.")
            .EmailAddress().WithMessage("Email must be a valid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password must be provided.")
            .MinimumLength(PasswordMinLength)
            .WithMessage($"Password must be at least {PasswordMinLength} characters long.")
            .Matches(PasswordRegex).WithMessage("Password must contain both letters and numbers.");
    }
}