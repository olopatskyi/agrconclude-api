using agrconclude.Domain.Entities;
using agrconclude.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace agrconclude.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<string>, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contract>? Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}