using Common.L4.Query.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Infrastructure.RazorUtils;

public class BaseRazorFilter<TFilterParam> : PageModel where TFilterParam : BaseFilterParam
{
    [BindProperty(SupportsGet = true)]
    public TFilterParam FilterParams { get; set; }
}