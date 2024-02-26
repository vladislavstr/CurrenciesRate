using CurrenciesRateDal.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesRateDal
{
    public class CurrencyContext : DbContext
    {
        /// <summary>
        /// delete before production!
        /// </summary>
        public CurrencyContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<CurrencyEntity> Currency { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CurrencyDbConnect"));
        }
    }
}
