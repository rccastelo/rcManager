using Microsoft.Extensions.DependencyInjection;
using rcManagerDatas.Interfaces;
using rcManagerDatas.Datas;

namespace rcManagerDatas.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISystemData, SystemData>();
            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IAccessData, AccessData>();
        }
    }
}
