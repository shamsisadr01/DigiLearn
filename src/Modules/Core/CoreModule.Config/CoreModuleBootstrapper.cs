﻿using CoreModule.Application.Category.Create;
using CoreModule.Domain.Category.DomainServices;
using CoreModule.Domain.Course.DomainService;
using CoreModule.Domain.Teacher.DomainServices;
using CoreModule.Facade;
using CoreModule.Infrastructure;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Config
{
    public static class CoreModuleBootstrapper
    {
        public static IServiceCollection InitCoreModule(this IServiceCollection services, IConfiguration configuration)
        {
            CoreModuleFacadeBootstrapper.RegisterDependency(services);
            CoreModuleInfrastructureBootstrapper.RegisterDependency(services, configuration);
            //CoreModuleQueryBootstrapper.RegisterDependency(services, configuration);

            services.AddMediatR(ctf =>
            {
                ctf.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly);
            });
            services.AddValidatorsFromAssembly(typeof(CreateCategoryCommand).Assembly);

           /* services.AddScoped<ICourseDomainService, CourseDomainService>();
            services.AddScoped<ITeacherDomainService, TeacherDomainService>();
            services.AddScoped<ICategoryDomainService, CategoryDomainService>();
            services.AddScoped<IOrderDomainService, OrderDomainService>();*/

            return services;
        }
    }
}