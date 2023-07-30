using Microsoft.EntityFrameworkCore;
using StockAPI.Models;

namespace StockAPI.Infrastructure;

public class ApplicationDbContext : DbContext
{
    //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //   : base(options) { }

    //public DbSet<StockTrade> StockTrades => Set<StockTrade>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // In memory DB with EF for now.
        // Replace with SQL server or something more substantial.
        optionsBuilder.UseInMemoryDatabase(databaseName: "StockTrades");
    }

    public DbSet<StockTrade> StockTrades { get; set; }
}