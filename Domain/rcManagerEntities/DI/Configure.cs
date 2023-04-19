using Microsoft.Extensions.DependencyInjection;
using rcManagerEntities.Interfaces;
using rcManagerEntities.Entities;

namespace rcManagerEntities.DI
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserEntity, UserEntity>();
            services.AddScoped<IAccessEntity, AccessEntity>();
        }
    }
}
