using Microsoft.Extensions.DependencyInjection;
using rcManagerDatabase.EF;

namespace rcManagerDatabase.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ManagerDbContext, ManagerDbContext>();
        }
    }
}
