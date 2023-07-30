using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;

namespace StockAPI.Infrastructure;

public class StockTradeRepository : IStockTradeRepository
{
    public StockTradeRepository()
    {
        // Init test data
        var stockTrades = new List<StockTrade>()
        {
            new StockTrade(
                "HR",
                Guid.NewGuid(),
                100,
                50),
            new StockTrade(
                "HR",
                Guid.NewGuid(),
                50,
                5),
            new StockTrade(
                "TYL",
                Guid.NewGuid(),
                20,
                30),
            new StockTrade(
                "TYL",
                Guid.NewGuid(),
                10,
                20)
        };

        using (var context = new ApplicationDbContext())
        {
            context.StockTrades.AddRange(stockTrades);
            context.SaveChangesAsync();
        };
    }

    public void Create(StockTrade stockTrade)
    {
        using (var context = new ApplicationDbContext())
        {
            context.StockTrades.Add(stockTrade);
            context.SaveChangesAsync();
        }
    }
}