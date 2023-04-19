using Microsoft.Extensions.DependencyInjection;
using rcManagerTransfer.Interfaces;
using rcManagerTransfer.Transfers;

namespace rcManagerTransfers.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISystemTransfer, SystemTransfer>();
            services.AddScoped<IUserTransfer, UserTransfer>();
            services.AddScoped<IAccessTransfer, AccessTransfer>();
        }
    }
}
