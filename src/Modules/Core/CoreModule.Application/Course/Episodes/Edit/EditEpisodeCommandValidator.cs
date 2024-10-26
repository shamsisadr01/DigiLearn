using FluentValidation;

namespace CoreModule.Application.Course.Episodes.Edit;

public class EditEpisodeCommandValidator : AbstractValidator<EditEpisodeCommand>
{
    public EditEpisodeCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull()
            .NotEmpty();
    }
}