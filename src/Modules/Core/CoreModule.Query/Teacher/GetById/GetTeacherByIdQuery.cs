using Common.L4.Query;
using CoreModule.Query.Teacher._DTOS;

namespace CoreModule.Query.Teacher.GetById;

public record GetTeacherByIdQuery(Guid Id) : IQuery<TeacherDto?>;