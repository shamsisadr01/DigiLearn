﻿using CoreModule.Facade.Course;
using DigiLearn.Infrastructure.RazorUtils;
using DigiLearn.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using CoreModule.Application.Course.Sections.Add;

namespace DigiLearn.Pages.Profile.Teacher.Courses.Sections
{
    [ServiceFilter(typeof(TeacherActionFilter))]
    [BindProperties]
    public class AddModel : BaseRazor
    {
        private ICourseFacade _courseFacade;

        public AddModel(ICourseFacade courseFacade)
        {
            _courseFacade = courseFacade;
        }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int DisplayOrder { get; set; }



        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Guid courseId)
        {
            var result = await _courseFacade.AddSection(new AddCourseSectionCommand()
            {
                Title = Title,
                DisplayOrder = DisplayOrder,
                CourseId = courseId,
            });

            return RedirectAndShowAlert(result, RedirectToPage("Index", new { courseId }));
        }
    }
}
