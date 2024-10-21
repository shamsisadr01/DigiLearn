using Common.L2.Application;
using CoreModule.Application.Teacher.AcceptRequest;
using CoreModule.Application.Teacher.Register;
using CoreModule.Application.Teacher.RejectRequset;
using MediatR;

namespace CoreModule.Facade.Teacher;

public class TeacherFacade : ITeacherFacade
{
    private readonly IMediator _mediator;

    public TeacherFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Register(RegisterTeacherCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AcceptRequest(AcceptTeacherRequestCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RejectRequest(RejectTeacherRequestCommand command)
    {
        return await _mediator.Send(command);
    }

    /*  public async Task<OperationResult> ToggleStatus(Guid teacherId)
    {
        return await _mediator.Send(new ToggleTeacherStatusCommand(teacherId));

    }*/

    /*  public async Task<TeacherDto?> GetById(Guid id)
    {
        return await _mediator.Send(new GetTeacherByIdQuery(id));
    }

    public async Task<TeacherDto?> GetByUserId(Guid userId)
    {
        return await _mediator.Send(new GetTeacherByUserIdQuery(userId));

    }

    public async Task<List<TeacherDto>> GetList()
    {
        return await _mediator.Send(new GetTeacherListQuery());
    }*/
}