using Common.L2.Application.Validation.FluentValidations;
using FluentValidation;

namespace UserModule.Core.Commands.Users.FullEdit;

public class FullEditUserCommandValidator : AbstractValidator<FullEditUserCommand>
{
    public FullEditUserCommandValidator()
    {
        RuleFor(f => f.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .ValidPhoneNumber();


        RuleFor(f => f.Email)
            .EmailAddress();
    }
}