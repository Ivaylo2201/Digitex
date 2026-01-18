using FluentValidation;

namespace Backend.Application.UseCases.Auth.SignIn;

public class SignInValidator : AbstractValidator<SignInRequest>
{
    public SignInValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(AuthConstants.EmailRequired)
            .EmailAddress().WithMessage(AuthConstants.EmailInvalid);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(AuthConstants.PasswordRequired)
            .MinimumLength(AuthConstants.PasswordMinLength).WithMessage(AuthConstants.PasswordTooShort)
            .Matches(AuthConstants.PasswordRegex).WithMessage(AuthConstants.PasswordRegexError);
    }
}
