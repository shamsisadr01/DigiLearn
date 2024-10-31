using CommentModule.Services.DTOs;
using CommentModule.Services;
using DigiLearn.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DigiLearn.Infrastructure.RazorUtils;

namespace DigiLearn.Areas.Admin.Pages.Comments
{
    public class IndexModel : BaseRazorFilter<CommentFilterParams>
    {
        private readonly ICommentService _commentService;

        public IndexModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public AllCommentFilterResult FilterResult { get; set; }

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
            FilterResult = await _commentService.GetAllComments(FilterParams);
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            return await AjaxTryCatch(() => _commentService.DeleteComment(id));
        }
    }
}
