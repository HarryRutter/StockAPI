using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;

namespace StockAPI.Infrastructure;

public class StockTradeRepository : IStockTradeRepository
{
    public void Create(StockTrade stockTrade)
    {
        try
        {
            using ApplicationDbContext context = new();

            context.StockTrades.Add(stockTrade);
            context.SaveChanges();

        }
        catch (Exception ex)
        {
            // Log error but skipped for brevity.
            throw;
        }

    }
}