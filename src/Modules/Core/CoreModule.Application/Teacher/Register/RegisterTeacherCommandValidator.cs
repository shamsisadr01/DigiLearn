using FluentValidation;

namespace CoreModule.Application.Teacher.Register;

public class RegisterTeacherCommandValidator : AbstractValidator<RegisterTeacherCommand>
{
    public RegisterTeacherCommandValidator()
    {
        RuleFor(r => r.CvFile)
            .NotEmpty()
            .NotNull();

        RuleFor(r => r.UserName)
            .NotEmpty()
            .NotNull();
    }
}