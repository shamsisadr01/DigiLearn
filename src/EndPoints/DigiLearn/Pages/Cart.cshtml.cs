using CoreModule.Application.Order.AddItem;
using CoreModule.Query.Order._DTOs;
using DigiLearn.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Entity.Infrastructure;
using CoreModule.Application.Order.RemoveItem;
using CoreModule.Facade.Orders;
using DigiLearn.Infrastructure;

namespace DigiLearn.Pages
{
    [Authorize]
    public class CartModel : BaseRazor
    {
        private readonly IOrderFacade _orderFacade;

        public CartModel(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public OrderDto? Order { get; set; }
        public async Task OnGet()
        {
            Order = await _orderFacade.GetCurrentOrder(User.GetUserId());
        }

        public void OnPost()
        {
           /* return RedirectToAction("CreateTransaction", "Transaction", new CreateTransactionCommand()
            {
                LinkId = Guid.NewGuid(),
                PaymentAmount = 0,
                UserId = User.GetUserId(),
                PaymentGateway = PaymentGateway.ZarinPal,
                TransactionFor = TransactionFor.CourseOrder
            });*/
        }
        public async Task<IActionResult> OnGetAddItem(Guid courseId)
        {
            var result = await _orderFacade.AddItem(new AddOrderItemCommand(User.GetUserId(), courseId));
            return RedirectAndShowAlert(result, RedirectToPage("/cart"));
        }
        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            return await AjaxTryCatch(() => _orderFacade.RemoveItem(new RemoveOrderItemCommand(User.GetUserId(), id)));
        }

    }
}
