using CoreModule.Query._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Query;

public class CoreModuleQueryBootstrapper
{
    public static void RegisterDependency(IServiceCollection services, IConfiguration configuration)
    {

        services.AddMediatR(scf =>
        {
            scf.RegisterServicesFromAssembly(typeof(QueryContext).Assembly);
        });

        services.AddDbContext<QueryContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("CoreModule_Context"));
        });
    }
}