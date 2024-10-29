using Common.L4.Query.Filter;
using CoreModule.Domain.Course.Enums;
using CoreModule.Facade.Course;
using CoreModule.Query.Course._DTOs;
using DigiLearn.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Pages
{
    public class CoursesModel : BaseRazorFilter<CourseFilterParams>
    {
        private ICourseFacade _courseFacade;

        public CoursesModel(ICourseFacade courseFacade)
        {
            _courseFacade = courseFacade;
        }

        public CourseFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterParams.ActionStatus = CourseActionStatus.Active;
            FilterParams.TeacherId = null;
            FilterResult = await _courseFacade.GetCourseFilter(FilterParams);
        }
    }
}
