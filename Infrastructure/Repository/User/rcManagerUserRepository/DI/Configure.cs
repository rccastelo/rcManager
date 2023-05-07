using Microsoft.Extensions.DependencyInjection;
using rcManagerUserRepository.Interfaces;
using rcManagerUserRepository.Repository;
using diDbSqlServerEF = rcDbSqlServerEF.Configure;

namespace rcManagerUserRepository.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            diDbSqlServerEF.ConfigureServices(services);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserData, UserData>();
        }
    }
}
