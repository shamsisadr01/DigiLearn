using DigiLearn.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModule.Core.Queries.Users._DTOs;
using UserModule.Core.Services;

namespace DigiLearn.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private IUserFacade _userFacade;
        public IndexModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public UserDto UserDto { get; set; }

        public async Task OnGet()
        {
            UserDto = await _userFacade.GetUserByPhoneNumber(User.GetUserPhoneNumber());
        }
    }
}
