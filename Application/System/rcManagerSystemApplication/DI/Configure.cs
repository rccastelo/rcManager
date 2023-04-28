using Microsoft.Extensions.DependencyInjection;
using rcManagerSystemApplication.Application;
using rcManagerSystemApplication.Interfaces;
using diDatabase = rcManagerDatabase.DI.Configure;

namespace rcManagerSystemApplication.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            diDatabase.ConfigureServices(services);
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<ISystemData, SystemData>();
        }
    }
}
