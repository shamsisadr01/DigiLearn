using Common.L4.Query;
using CoreModule.Query.Teacher._DTOS;

namespace CoreModule.Query.Teacher.GetByUserId;

public record GetTeacherByUserIdQuery(Guid UserId) : IQuery<TeacherDto?>;