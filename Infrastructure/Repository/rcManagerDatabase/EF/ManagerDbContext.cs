using Microsoft.EntityFrameworkCore;
using rcManagerPermissionDomain;
using rcManagerSystemDomain;
using rcManagerUserDomain;

namespace rcManagerDatabase.EF
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
