using CoreModule.Facade.Course;
using CoreModule.Facade.Teacher;
using CoreModule.Query.Course._DTOs;
using DigiLearn.Infrastructure;
using DigiLearn.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Pages.Profile.Teacher.Courses
{
    [ServiceFilter(typeof(TeacherActionFilter))]
    public class IndexModel : BaseRazorFilter<CourseFilterParams>
    {
        private readonly ICourseFacade _courseFacade;
        private readonly ITeacherFacade _teacherFacade;
        public IndexModel(ICourseFacade courseFacade, ITeacherFacade teacherFacade)
        {
            _courseFacade = courseFacade;
            _teacherFacade = teacherFacade;
        }
        public CourseFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            var teacher = await _teacherFacade.GetByUserId(User.GetUserId());
            FilterParams.TeacherId = teacher!.Id;
            FilterResult = await _courseFacade.GetCourseFilter(FilterParams);
        }
    }
}
