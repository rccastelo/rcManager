using Microsoft.Extensions.Configuration;
using rcDbSqlServerEF;

namespace rcManagerMigrations
{
    public class MigrationsDbContext : ManagerDbContext
    {
        public MigrationsDbContext(IConfiguration configuration) : base(configuration) { }
    }
}
