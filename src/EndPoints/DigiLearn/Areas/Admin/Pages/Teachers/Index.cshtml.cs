using CoreModule.Facade.Teacher;
using CoreModule.Query.Teacher._DTOS;
using DigiLearn.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Areas.Admin.Pages.Teachers
{
    public class IndexModel : BaseRazor
    {
        private readonly ITeacherFacade _teacherFacade;

        public IndexModel(ITeacherFacade teacherFacade)
        {
            _teacherFacade = teacherFacade;
        }

        public List<TeacherDto> Teachers { get; set; }
        public async Task OnGet()
        {
            Teachers = await _teacherFacade.GetList();
        }

        public async Task<IActionResult> OnPostToggleStatus(Guid id)
        {
            return await AjaxTryCatch(() => _teacherFacade.ToggleStatus(id));
        }
    }
}
