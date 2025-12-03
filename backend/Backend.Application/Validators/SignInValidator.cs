using Backend.Application.Dtos.User;
using FluentValidation;

namespace Backend.Application.Validators;

public class SignInValidator : AbstractValidator<SignInDto>
{
    public SignInValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(Constants.EmailRequired)
            .EmailAddress().WithMessage(Constants.EmailInvalid);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(Constants.PasswordRequired)
            .MinimumLength(Constants.PasswordMinLength).WithMessage(Constants.PasswordTooShort)
            .Matches(Constants.PasswordRegex).WithMessage(Constants.PasswordRegexError);
    }
}
