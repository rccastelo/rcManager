using Microsoft.Extensions.DependencyInjection;
using rcManagerUserApplication.Application;
using rcManagerUserApplication.Interfaces;
using diDatabase = rcManagerDatabase.DI.Configure;

namespace rcManagerUserApplication.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            diDatabase.ConfigureServices(services);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserData, UserData>();
        }
    }
}
