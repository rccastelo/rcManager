using Microsoft.Extensions.DependencyInjection;
using rcManagerUserApplication.Interfaces;
using rcManagerUserApplication.Service;
using diUserRepository = rcManagerUserRepository.DI.Configure;

namespace rcManagerUserApplication.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            diUserRepository.ConfigureServices(services);
        }
    }
}
