using Microsoft.EntityFrameworkCore;

namespace rcManagerDatabase
{
    public class ManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.GetConnectionString());
        }
    }
}
