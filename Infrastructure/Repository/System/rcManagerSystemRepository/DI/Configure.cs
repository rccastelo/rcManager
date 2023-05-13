using Microsoft.Extensions.DependencyInjection;
using rcManagerSystemRepository.Datas;
using rcManagerSystemRepository.Interfaces;
using rcManagerSystemRepository.Repositories;
using diDbSqlServerEF = rcDbSqlServerEF.Configure;

namespace rcManagerSystemRepository.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISystemRepository, SystemRepository>();
            services.AddScoped<ISystemData, SystemData>();
            diDbSqlServerEF.ConfigureServices(services);
        }
    }
}
