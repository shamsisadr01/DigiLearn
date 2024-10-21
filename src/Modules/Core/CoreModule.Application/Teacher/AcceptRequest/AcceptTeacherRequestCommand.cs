using Common.L2.Application;

namespace CoreModule.Application.Teacher.AcceptRequest;

public class AcceptTeacherRequestCommand : IBaseCommand
{
    public Guid TeacherId { get; set; }
}