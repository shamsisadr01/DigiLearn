using DigiLearn.Infrastructure;
using DigiLearn.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketModule.Core.DTOs;
using TicketModule.Core.Services;

namespace DigiLearn.Pages.Profile.Tickets
{
    public class IndexModel : BaseRazorFilter<TicketFilterParams>
    {
        private ITicketService _ticketService;

        public IndexModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public TicketFilterResult FilterResult { get; set; }

        public async Task OnGet()
        {
            FilterResult = await _ticketService.GetTicketsByFilter(new TicketFilterParams()
            {
                UserId = User.GetUserId(),
                Take = 10,
                PageId = FilterParams.PageId
            });
        }
    }
}
