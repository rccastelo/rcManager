using Microsoft.Extensions.DependencyInjection;
using rcManagerPermissionRepository.Datas;
using rcManagerPermissionRepository.Interfaces;
using rcManagerPermissionRepository.Repositories;
using diDbSqlServerEF = rcDbSqlServerEF.Configure;

namespace rcManagerPermissionRepository.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionData, PermissionData>();
            diDbSqlServerEF.ConfigureServices(services);
        }
    }
}
