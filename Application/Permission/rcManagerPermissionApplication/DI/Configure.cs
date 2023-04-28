using Microsoft.Extensions.DependencyInjection;
using rcManagerPermissionApplication.Application;
using rcManagerPermissionApplication.Interfaces;
using diDatabase = rcManagerDatabase.DI.Configure;

namespace rcManagerPermissionApplication.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            diDatabase.ConfigureServices(services);
            services.AddScoped<IPermissionData, PermissionData>();
            services.AddScoped<IPermissionService, PermissionService>();
        }
    }
}
