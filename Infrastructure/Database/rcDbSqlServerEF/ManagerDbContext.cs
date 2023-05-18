using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using rcManagerPermissionDomain.Entities;
using rcManagerSystemDomain.Entities;
using rcManagerUserDomain.Entities;

namespace rcDbSqlServerEF
{
    public class ManagerDbContext : DbContext
    {
        private string _connectionString;
        private IConfiguration _configuration;

        public ManagerDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LoginEntity>()
                .HasIndex(et => et.Login)
                .IsUnique();
        }

        public DbSet<SystemEntity> Systems { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<LoginEntity> Logins { get; set; }
    }
}
