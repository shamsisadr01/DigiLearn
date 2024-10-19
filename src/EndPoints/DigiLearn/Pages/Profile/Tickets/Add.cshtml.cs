using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DigiLearn.Infrastructure;
using DigiLearn.Infrastructure.RazorUtils;
using TicketModule.Core.DTOs;
using TicketModule.Core.Services;
using UserModule.Core.Services;

namespace DigiLearn.Pages.Profile.Tickets
{
    [BindProperties]
    public class AddModel : BaseRazor
    {
        private IUserFacade _userFacade;
        private ITicketService _ticketService;

        public AddModel(IUserFacade userFacade, ITicketService ticketService)
        {
            _userFacade = userFacade;
            _ticketService = ticketService;
        }

        [Display(Name = "عنوان تیکت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "متن تیکت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userFacade.GetUserByPhoneNumber(User.GetUserPhoneNumber());
            var command = new CreateTicketCommand()
            {
                PhoneNumber = user.PhoneNumber,
                OwnerFullName = $"{user.Name} {user.Family}",
                Text = Text,
                Title = Title,
                UserId = user.Id
            };
            var result = await _ticketService.CreateTicket(command);

            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
