using Common.L2.Application.SecurityUtil;
using DigiLearn.Infrastructure.JwtUtil;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DigiLearn.Infrastructure.RazorUtils;
using UserModule.Core.Services;

namespace DigiLearn.Pages.Auth
{
    [BindProperties]
    public class LoginModel : BaseRazor
    {
        private IUserFacade _userFacade;
        private IConfiguration _configuration;
        public LoginModel(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        public bool IsRememberMe { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userFacade.GetUserByPhoneNumber(PhoneNumber);
            if (user == null)
            {
                ErrorAlert("کاربری با مشخصات وارد شده یافت نشد");
                return Page();
            }
            var isComparePassword = Sha256Hasher.IsCompare(user.Password, Password);
            if (isComparePassword == false)
            {
                ErrorAlert("کاربری با مشخصات وارد شده یافت نشد");
                return Page();
            }

            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            if (IsRememberMe)
            {
                HttpContext.Response.Cookies.Append("digi-token", token, new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.Now.AddDays(30),
                    Secure = true
                });
            }
            else
            {
                HttpContext.Response.Cookies.Append("digi-token", token, new CookieOptions()
                {
                    HttpOnly = true,
                    Secure = true
                });
            }

            return RedirectToPage("../Index");
        }
    }
}
