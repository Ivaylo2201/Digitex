using Backend.Application.Dtos.Authentication;
using FluentValidation;

namespace Backend.Application.Validators;

public class SignUpValidator : AbstractValidator<SignUpDto>
{
    public SignUpValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(Constants.EmailRequired)
            .EmailAddress().WithMessage(Constants.EmailInvalid);

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(Constants.UsernameRequired)
            .MinimumLength(Constants.UsernameMinLength).WithMessage(Constants.UsernameTooShort)
            .MaximumLength(Constants.UsernameMaxLength).WithMessage(Constants.UsernameTooLong);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(Constants.PasswordRequired)
            .MinimumLength(Constants.PasswordMinLength).WithMessage(Constants.PasswordTooShort)
            .Matches(Constants.PasswordRegex).WithMessage(Constants.PasswordRegexError);

        RuleFor(x => x.PasswordConfirmation)
            .NotEmpty().WithMessage(Constants.PasswordRequired)
            .MinimumLength(Constants.PasswordMinLength).WithMessage(Constants.PasswordTooShort)
            .Matches(Constants.PasswordRegex).WithMessage(Constants.PasswordRegexError);

        RuleFor(x => x)
            .Must(x => x.Password == x.PasswordConfirmation)
            .WithMessage(Constants.PasswordMismatch)
            .WithName("passwordConfirmation");

        RuleFor(x => x)
            .Must(x => !x.Password.Contains(x.Username.ToLower(), StringComparison.OrdinalIgnoreCase))
            .WithMessage(Constants.PasswordContainsUsername);
    }
}
