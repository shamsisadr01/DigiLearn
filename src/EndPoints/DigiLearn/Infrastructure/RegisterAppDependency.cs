﻿
using Common.EventBus.Abstractions;
using Common.EventBus.RabbitMQ;
using DigiLearn.Infrastructure.RazorUtils;
using DigiLearn.Infrastructure.Services;

namespace DigiLearn.Infrastructure;

public static class RegisterAppDependency
{
	public static void RegisterDependency(this IServiceCollection services)
	{
		var baseAddress = "https://localhost:5001/api/";

        services.AddHttpContextAccessor();
        services.AddTransient<IRenderViewToString,RenderViewToString>();

        services.AddSingleton<IEventBus, EventBusRabbitMQ>();

        services.AddScoped<IHomePageService, HomePageService>();

    }
}