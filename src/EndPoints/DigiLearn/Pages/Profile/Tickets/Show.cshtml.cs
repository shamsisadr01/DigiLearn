﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using DigiLearn.Infrastructure.RazorUtils;
using TicketModule.Core.DTOs;
using TicketModule.Core.Services;
using UserModule.Core.Services;
using DigiLearn.Infrastructure;
using Common.L2.Application;

namespace DigiLearn.Pages.Profile.Tickets
{
    public class ShowModel : BaseRazor
    {
        private ITicketService _ticketService;
        private IUserFacade _userFacade;
        public ShowModel(ITicketService ticketService, IUserFacade userFacade)
        {
            _ticketService = ticketService;
            _userFacade = userFacade;
        }

        public TicketDto Ticket { get; set; }


        [BindProperty]
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Text { get; set; }

        public async Task<IActionResult> OnGet(Guid ticketId)
        {
            var ticket = await _ticketService.GetTicket(ticketId);
            if (ticket == null || ticket.UserId != User.GetUserId())
                return RedirectToPage("Index");


            Ticket = ticket;
            return Page();
        }

        public async Task<IActionResult> OnPost(Guid ticketId)
        {
            var user = await _userFacade.GetUserByPhoneNumber(User.GetUserPhoneNumber());
            var message = new SendTicketMessageCommand()
            {
                OwnerFullName = $"{user.Name} {user.Family}",
                Text = Text,
                TicketId = ticketId,
                UserId = User.GetUserId()
            };
            var result = await _ticketService.SendMessageInTicket(message);
            return RedirectAndShowAlert(result, RedirectToPage("Show", new { ticketId }));
        }

        public async Task<IActionResult> OnPostCloseTicket(Guid ticketId)
        {
            return await AjaxTryCatch(async () =>
            {
                var ticket = await _ticketService.GetTicket(ticketId);
                if (ticket == null || ticket.UserId != User.GetUserId())
                    return OperationResult.Error("تیکت یافت نشد");

                return await _ticketService.CloseTicket(ticketId);
            });
        }
    }
}
