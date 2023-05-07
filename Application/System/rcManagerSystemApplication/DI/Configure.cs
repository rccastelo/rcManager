using Microsoft.Extensions.DependencyInjection;
using rcManagerSystemApplication.Service;
using rcManagerSystemApplication.Interfaces;
using diSystemRepository = rcManagerSystemRepository.DI.Configure;

namespace rcManagerSystemApplication.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISystemService, SystemService>();
            diSystemRepository.ConfigureServices(services);
        }
    }
}
