using DigiLearn.Infrastructure.RazorUtils;
using DigiLearn.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModule.Core.Queries._DTOs;
using UserModule.Core.Services;

namespace DigiLearn.Areas.Admin.Pages.Users
{
    public class IndexModel : BaseRazorFilter<UserFilterParams>
    {
        private readonly IUserFacade _userFacade;

        public IndexModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public UserFilterResult FilterResult { get; set; }

        public async Task OnGet(string stDate, string enDate)
        {
            if (string.IsNullOrWhiteSpace(stDate) == false)
            {
                FilterParams.StartDate = stDate.ToMiladi();
            }
            if (string.IsNullOrWhiteSpace(enDate) == false)
            {
                FilterParams.EndDate = enDate.ToMiladi();
            }
            FilterResult = await _userFacade.GetByFilter(FilterParams);
        }
    }
}
