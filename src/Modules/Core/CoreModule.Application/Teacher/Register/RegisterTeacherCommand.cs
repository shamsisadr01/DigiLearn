using Common.L2.Application;
using Microsoft.AspNetCore.Http;

namespace CoreModule.Application.Teacher.Register;

public class RegisterTeacherCommand : IBaseCommand
{
    public IFormFile CvFile { get; set; }
    public string UserName { get; set; }
    public Guid UserId { get; set; }
}