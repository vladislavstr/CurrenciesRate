using CurrenciesRateDal.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesRateDal
{
    internal class CurrencyContext : DbContext
    {
        public DbSet<CurrencyEntity> Currency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CurrencyDbConnect"));
            optionsBuilder.UseInMemoryDatabase("CurrencyDb");
        }
    }
}
