using CoreModule.Domain.Category.Repository;
using CoreModule.Domain.Course.Repository;
using CoreModule.Domain.Order.Repositories;
using CoreModule.Domain.Teacher.Repositories;
using CoreModule.Infrastructure.EventHandlers;
using CoreModule.Infrastructure.Persistent.Category;
using CoreModule.Infrastructure.Persistent.Course;
using CoreModule.Infrastructure.Persistent.Teacher;
using CoreModule.Infrastructure.Persistent;
using CoreModule.Infrastructure.Persistent.OrderConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Infrastructure;

public class CoreModuleInfrastructureBootstrapper
{
    public static void RegisterDependency(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddHostedService<UserChangeAvatarEventHandler>();

        services.AddHostedService<UserRegisteredEventHandler>();
        services.AddHostedService<UserEditedEventHandler>();

        services.AddDbContext<CoreModuleEfContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("CoreModule_Context"));
        });
    }
}