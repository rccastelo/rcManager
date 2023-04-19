using Microsoft.Extensions.DependencyInjection;
using rcManagerServices.Interfaces;
using rcManagerServices.Services;

namespace rcManagerServices.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISystemService, SystemService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccessService, AccessService>();
        }
    }
}
