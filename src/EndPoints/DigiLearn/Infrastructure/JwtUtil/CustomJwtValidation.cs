using Microsoft.AspNetCore.Authentication.JwtBearer;
using UserModule.Core.Services;

namespace DigiLearn.Infrastructure.JwtUtil;

public class CustomJwtValidation
{
	private IUserFacade _userFacade;

	public CustomJwtValidation(IUserFacade userFacade)
	{
		_userFacade = userFacade;
	}


	public async Task Validate(TokenValidatedContext context)
	{
		//var userId = context.Principal.GetUserId();
		//var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
		//var token = await _userFacade.GetUserTokenByJwtToken(jwtToken);
		//if (token == null)
		//{
		//	context.Fail("توکن پیدا نشد.");
		//	return;
		//}

		//var user = await _userFacade.GetUserById(userId);
		//if (user == null || user.IsActive == false)
		//{
		//	context.Fail("کاربر پیدا نشد.");
		//	return;
		//}
	}
}