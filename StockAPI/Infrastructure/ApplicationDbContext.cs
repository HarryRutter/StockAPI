using Microsoft.EntityFrameworkCore;
using StockAPI.Models;

namespace StockAPI.Infrastructure;

public class ApplicationDbContext : DbContext
{
    // Would pull this / the full connection string from the config so it could easily be replaced per env.
    private const string _dbName = "StockAPI";
    
    public DbSet<StockTrade> StockTrades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // In memory DB with EF for now.
        // Replace with SQL server or something more substantial later!
        optionsBuilder.UseInMemoryDatabase(databaseName: _dbName);
    }
}