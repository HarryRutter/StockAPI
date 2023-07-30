using Microsoft.EntityFrameworkCore;
using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;

namespace StockAPI.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options) { }

    public DbSet<StockTrade> StockTrades => Set<StockTrade>();
}