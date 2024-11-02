using CoreModule.Domain.Teacher.Enums;
using CoreModule.Facade.Teacher;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.Infrastructure;

public class TeacherActionFilter : ActionFilterAttribute
{
    private readonly ITeacherFacade _teacherFacade;

    public TeacherActionFilter(ITeacherFacade teacherFacade)
    {
        _teacherFacade = teacherFacade;
    }

    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.HttpContext.User.Identity.IsAuthenticated == false)
            context.Result = new RedirectResult("/");
        var teacher = await _teacherFacade.GetByUserId(context.HttpContext.User.GetUserId());
        if (teacher == null || teacher.Status != TeacherStatus.Active)
            context.Result = new RedirectResult("/Profile");
        await next();
    }

}