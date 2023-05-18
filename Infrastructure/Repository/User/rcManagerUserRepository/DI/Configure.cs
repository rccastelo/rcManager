using Microsoft.Extensions.DependencyInjection;
using rcManagerUserRepository.Datas;
using rcManagerUserRepository.Interfaces;
using rcManagerUserRepository.Repositories;
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
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginData, LoginData>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
        }
    }
}
