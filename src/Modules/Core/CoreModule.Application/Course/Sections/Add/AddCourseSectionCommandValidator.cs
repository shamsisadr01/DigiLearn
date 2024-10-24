using FluentValidation;

namespace CoreModule.Application.Course.Sections.Add;

internal class AddCourseSectionCommandValidator : AbstractValidator<AddCourseSectionCommand>
{
    public AddCourseSectionCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty()
            .NotNull();
    }
}