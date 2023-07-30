using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;

namespace StockAPI.Infrastructure;

public class StockTradeRepository : IStockTradeRepository
{ 
    public void Create(StockTrade stockTrade)
    {
        using (var context = new ApplicationDbContext())
        {
            context.StockTrades.Add(stockTrade);
            context.SaveChangesAsync();
        }
    }
}