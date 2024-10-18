
using DigiLearn.Infrastructure.RazorUtils;

namespace DigiLearn.Infrastructure;

public static class RegisterServices
{
	public static void RegisterApiServices(this IServiceCollection services)
	{
		var baseAddress = "https://localhost:5001/api/";

        services.AddHttpContextAccessor();
        services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
        services.AddTransient<IRenderViewToString,RenderViewToString>();

    }
}