using Common.L2.Application;

namespace CoreModule.Application.Course.Sections.Add;

public class AddCourseSectionCommand : IBaseCommand
{
    public Guid CourseId { get; set; }
    public string Title { get; set; }
    public int DisplayOrder { get; set; }
}