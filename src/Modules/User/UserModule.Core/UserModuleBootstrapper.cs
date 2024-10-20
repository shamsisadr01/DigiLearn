﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserModule.Core.Services;
using UserModule.Data;

namespace UserModule.Core;

public static class UserModuleBootstrapper
{
    public static IServiceCollection InitUserModule(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<UserContext>(option =>
        {
            option.UseSqlServer(config.GetConnectionString("User_Context"));
        });

        services.AddAutoMapper(typeof(UserModuleBootstrapper).Assembly);
        services.AddValidatorsFromAssembly(typeof(UserModuleBootstrapper).Assembly);
        services.AddMediatR(ctf=>ctf.RegisterServicesFromAssembly(typeof(UserModuleBootstrapper).Assembly));

        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<INotificationFacade, NotificationFacade>();

        return services;
    }
}