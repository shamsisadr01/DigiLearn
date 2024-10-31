using BlogModule.Service.DTOs.Query;
using BlogModule.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DigiLearn.Infrastructure.RazorUtils;

namespace DigiLearn.Pages.Blog
{
    public class IndexModel : BaseRazorFilter<BlogPostFilterParams>
    {
        private IBlogService _blogService;

        public IndexModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public List<BlogCategoryDto> Categories { get; set; }
        public BlogPostFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _blogService.GetPostsByFilter(FilterParams);
            Categories = await _blogService.GetAllCategories();
        }
    }
}
