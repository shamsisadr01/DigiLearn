using Common.L2.Application;
using CoreModule.Domain.Course.Repository;

namespace CoreModule.Application.Course.Sections.Add;

class AddCourseSectionCommandHandler : IBaseCommandHandler<AddCourseSectionCommand>
{
    private readonly ICourseRepository _repository;

    public AddCourseSectionCommandHandler(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddCourseSectionCommand request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetTracking(request.CourseId);
        if (course == null)
        {
            return OperationResult.NotFound();
        }

        course.AddSection(request.DisplayOrder, request.Title);
        await _repository.Save();
       
      
        return OperationResult.Success();
    }
}