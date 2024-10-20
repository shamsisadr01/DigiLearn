using DigiLearn.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModule.Core.Queries._DTOs;
using UserModule.Core.Services;

namespace DigiLearn.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly IUserFacade _userFacade;
        private readonly INotificationFacade _notificationFacade;


        public IndexModel(IUserFacade userFacade, INotificationFacade notificationFacade)
        {
            _userFacade = userFacade;
            _notificationFacade = notificationFacade;
        }

        public List<NotificationFilterData> NewNotification { get; set; }

        public UserDto UserDto { get; set; }

        public async Task OnGet()
        {
            UserDto = await _userFacade.GetUserByPhoneNumber(User.GetUserPhoneNumber());
            var result = await _notificationFacade.GetByFilter(new NotificationFilterParams()
            {
                IsSeen = false,
                PageId = 1,
                Take = 5,
                UserId = UserDto!.Id
            });
            NewNotification = result.Data;
        }
    }
}
