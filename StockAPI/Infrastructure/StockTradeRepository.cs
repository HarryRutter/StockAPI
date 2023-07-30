using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;

namespace StockAPI.Infrastructure;

public class StockTradeRepository : IStockTradeRepository
{ 
    public void Create(StockTrade stockTrade)
    {       
        using (ApplicationDbContext context = new())
        {            
            context.StockTrades.Add(stockTrade);
            context.SaveChanges();
        }
    }
}