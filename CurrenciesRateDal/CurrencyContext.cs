using CurrenciesRateDal.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesRateDal
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<CurrencyEntity> Currency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CurrencyDbConnect"));
        }
    }
}
