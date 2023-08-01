using CRUDSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDSystem.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }

    }
}
