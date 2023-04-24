using Microsoft.EntityFrameworkCore;
using rcManagerEntities.Entities;

namespace rcManagerDatabase
{
    public class ManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.GetConnectionString());
        }

        public DbSet<SystemEntity> Systems { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
    }
}
