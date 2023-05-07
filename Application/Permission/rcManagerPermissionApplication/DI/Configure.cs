using Microsoft.Extensions.DependencyInjection;
using rcManagerPermissionApplication.Service;
using rcManagerPermissionApplication.Interfaces;
using diPermissionRepository = rcManagerPermissionRepository.DI.Configure;

namespace rcManagerPermissionApplication.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPermissionService, PermissionService>();
            diPermissionRepository.ConfigureServices(services);
        }
    }
}
