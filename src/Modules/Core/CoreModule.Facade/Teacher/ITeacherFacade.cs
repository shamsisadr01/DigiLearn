using Common.L2.Application;
using CoreModule.Application.Teacher.AcceptRequest;
using CoreModule.Application.Teacher.Register;
using CoreModule.Application.Teacher.RejectRequset;
using CoreModule.Query.Teacher._DTOS;

namespace CoreModule.Facade.Teacher;

public interface ITeacherFacade
{
    Task<OperationResult> Register(RegisterTeacherCommand command);
    Task<OperationResult> AcceptRequest(AcceptTeacherRequestCommand command);
    Task<OperationResult> RejectRequest(RejectTeacherRequestCommand command);
    Task<OperationResult> ToggleStatus(Guid teacherId);



    Task<TeacherDto?> GetById(Guid id);
    Task<TeacherDto?> GetByUserId(Guid userId);
    Task<List<TeacherDto>> GetList();
}