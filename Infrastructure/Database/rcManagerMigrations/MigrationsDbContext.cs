using rcDbSqlServerEF;

namespace rcManagerMigrations
{
    public class MigrationsDbContext : ManagerDbContext
    {
        public MigrationsDbContext() : base(Settings.GetSettings()) { }
    }
}
