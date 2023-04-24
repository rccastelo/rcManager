using Microsoft.Extensions.DependencyInjection;
using rcManagerDatas.Datas;
using rcManagerDatas.Interfaces;
using diDatabase = rcManagerDatabase.DI.Configure;

namespace rcManagerDatas.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            diDatabase.ConfigureServices(services);
            services.AddScoped<ISystemData, SystemData>();
            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IPermissionData, PermissionData>();
        }
    }
}
