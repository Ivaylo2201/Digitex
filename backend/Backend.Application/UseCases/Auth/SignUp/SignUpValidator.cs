using FluentValidation;

namespace Backend.Application.UseCases.Auth.SignUp;

public class SignUpValidator : AbstractValidator<SignUpRequest>
{
    public SignUpValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(AuthConstants.EmailRequired)
            .EmailAddress().WithMessage(AuthConstants.EmailInvalid);

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(AuthConstants.UsernameRequired)
            .MinimumLength(AuthConstants.UsernameMinLength).WithMessage(AuthConstants.UsernameTooShort)
            .MaximumLength(AuthConstants.UsernameMaxLength).WithMessage(AuthConstants.UsernameTooLong);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(AuthConstants.PasswordRequired)
            .MinimumLength(AuthConstants.PasswordMinLength).WithMessage(AuthConstants.PasswordTooShort)
            .Matches(AuthConstants.PasswordRegex).WithMessage(AuthConstants.PasswordRegexError);

        RuleFor(x => x.PasswordConfirmation)
            .NotEmpty().WithMessage(AuthConstants.PasswordRequired)
            .MinimumLength(AuthConstants.PasswordMinLength).WithMessage(AuthConstants.PasswordTooShort)
            .Matches(AuthConstants.PasswordRegex).WithMessage(AuthConstants.PasswordRegexError);

        RuleFor(x => x)
            .Must(x => x.Password == x.PasswordConfirmation)
            .WithMessage(AuthConstants.PasswordMismatch)
            .WithName("passwordConfirmation");

        RuleFor(x => x)
            .Must(x => !x.Password.Contains(x.Username.ToLower(), StringComparison.OrdinalIgnoreCase))
            .WithMessage(AuthConstants.PasswordContainsUsername);
    }
}
