using Common.L4.Query;
using CoreModule.Domain.Teacher.Enums;
using CoreModule.Query._DTOS;

namespace CoreModule.Query.Teacher._DTOS;

public class TeacherDto : BaseDto
{
    public string UserName { get; set; }
    public string CvFileName { get; set; }
    public TeacherStatus Status { get; set; }
    public CoreModuleUserDto User { get; set; }
}