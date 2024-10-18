using FluentValidation;

namespace UserModule.Core.Commands.Users.Register;

public class RegisterUserCommandValidation : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidation()
    {
        RuleFor(r => r.Password)
            .NotEmpty()
            .NotNull().MinimumLength(6);
    }
}