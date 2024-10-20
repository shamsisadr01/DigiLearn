using FluentValidation;

namespace UserModule.Core.Commands.Notifications.Create;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(n => n.Title).NotEmpty().NotNull();
        RuleFor(n => n.Text).NotEmpty().NotNull();
    }
}