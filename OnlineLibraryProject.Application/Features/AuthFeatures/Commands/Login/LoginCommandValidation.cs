using FluentValidation;

namespace OnlineLibraryProject.Application.Features.AuthFeatures.Commands.Login;

public class LoginCommandValidation : AbstractValidator<LoginCommand>
{
    public LoginCommandValidation()
    {
        RuleFor(c => c.UsernameOrEmail).NotEmpty().WithMessage("Username or email field is required!");
        RuleFor(c => c.UsernameOrEmail).NotNull().WithMessage("Username or email field is required!");
        RuleFor(c => c.UsernameOrEmail).MinimumLength(3).WithMessage("Username or email must be greater than 3 characters!");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Password field is required!");
        RuleFor(p => p.Password).NotNull().WithMessage("Password field is required!");

    }
}
