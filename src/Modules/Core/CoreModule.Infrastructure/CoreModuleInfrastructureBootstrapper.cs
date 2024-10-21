using CoreModule.Domain.Category.Repository;
using CoreModule.Domain.Course.Repository;
using CoreModule.Domain.Teacher.Repositories;
using CoreModule.Infrastructure.Persistent.Category;
using CoreModule.Infrastructure.Persistent.Course;
using CoreModule.Infrastructure.Persistent.Teacher;
using CoreModule.Infrastructure.Persistent;
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
        /*services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddHostedService<UserRegisteredEventHandler>();
        services.AddHostedService<UserEditedEventHandler>();
        services.AddHostedService<UserChangeAvatarEventHandler>();*/

        services.AddDbContext<CoreModuleEfContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("CoreModule_Context"));
        });
    }
}