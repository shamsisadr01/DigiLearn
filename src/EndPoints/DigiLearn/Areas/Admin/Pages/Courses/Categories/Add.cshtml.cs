using Common.L1.Domain.Utilities;
using CoreModule.Application.Category.AddChild;
using CoreModule.Application.Category.Create;
using CoreModule.Facade.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DigiLearn.Infrastructure.RazorUtils;

namespace DigiLearn.Areas.Admin.Pages.Courses.Categories
{
    [BindProperties]
    public class AddModel : BaseRazor
    {
        private ICourseCategoryFacade _categoryFacade;

        public AddModel(ICourseCategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "عنوان انگلیسی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Slug { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost([FromQuery] Guid? parentId)
        {
            if (parentId != null)
            {
                var result = await _categoryFacade.AddChild(new AddChildCategoryCommand()
                {
                    Title = Title,
                    Slug = Slug.ToSlug(),
                    ParentCategoryId = parentId.Value
                });

                return RedirectAndShowAlert(result, RedirectToPage("Index"));
            }
            else
            {
                var result = await _categoryFacade.Create(new CreateCategoryCommand
                {
                    Title = Title,
                    Slug = Slug.ToSlug()
                });

                return RedirectAndShowAlert(result, RedirectToPage("Index"));
            }

        }
    }
}
