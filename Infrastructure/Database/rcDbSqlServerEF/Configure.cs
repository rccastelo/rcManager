using Microsoft.Extensions.DependencyInjection;

namespace rcDbSqlServerEF
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ManagerDbContext, ManagerDbContext>();
        }
    }
}
