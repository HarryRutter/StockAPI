using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;

namespace StockAPI.Infrastructure;

public class StockTradeRepository : IStockTradeRepository
{ 
    public void Create(StockTrade stockTrade)
    {
        try
        {
            // Validate method will throw exception if business rules aren't satisfied.
            stockTrade.Validate();

            // If no exceptions, ok to create.
            using (ApplicationDbContext context = new())
            {
                context.StockTrades.Add(stockTrade);
                context.SaveChanges();
            }
        }
        // If threw custom validation messages, could check for each and return different response code.
        // For now just catching and throwing.
        catch
        {
            throw;
        }
        
    }
}