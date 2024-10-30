using BlogModule.Service.DTOs.Query;
using BlogModule.Service;
using DigiLearn.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using BlogModule.Service.DTOs.Command;
using Common.L2.Application;

namespace DigiLearn.Areas.Admin.Pages.Blog.Categories
{
    public class IndexModel : BaseRazor
    {
        private IBlogService _service;
        private IRenderViewToString _renderView;
        public IndexModel(IBlogService service, IRenderViewToString renderView)
        {
            _service = service;
            _renderView = renderView;
        }

        public List<BlogCategoryDto> Categories { get; set; }


        [BindProperty]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [BindProperty]
        [Display(Name = "slug")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Slug { get; set; }
        public async Task OnGet()
        {
            Categories = await _service.GetAllCategories();
        }

        public async Task<IActionResult> OnGetShowEditPage(Guid id)
        {
            return await AjaxTryCatch(async () =>
            {
                var category = await _service.GetCategoryById(id);
                if (category == null)
                {
                    return OperationResult<string>.NotFound();
                }

                var viewResult = await _renderView.RenderToStringAsync("_Edit", new EditBlogCategoryCommand()
                {
                    Title = category.Title,
                    Slug = category.Slug,
                    Id = id
                }, PageContext);

                return OperationResult<string>.Success(viewResult);
            });
        }
        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            return await AjaxTryCatch(() => _service.DeleteCategory(id));
        }
        public async Task<IActionResult> OnPostEdit(EditBlogCategoryCommand command)
        {
            return await AjaxTryCatch(() => _service.EditCategory(command));
        }
        public async Task<IActionResult> OnPost()
        {
            return await AjaxTryCatch(() => _service.CreateCategory(new CreateBlogCategoryCommand()
            {
                Slug = Slug,
                Title = Title
            }));
        }
    }
}
