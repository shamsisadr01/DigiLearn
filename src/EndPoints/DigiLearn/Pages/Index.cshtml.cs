using DigiLearn.Infrastructure.Services;
using DigiLearn.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHomePageService _homePageService;

        public IndexModel(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        public HomePageViewModel HomePageData { get; set; }

        public async Task OnGet()
        {
            HomePageData = await _homePageService.GetData();
        }
    }
}
