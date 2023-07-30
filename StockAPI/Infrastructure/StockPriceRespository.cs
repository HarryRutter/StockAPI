using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models.DTOs;

namespace StockAPI.Infrastructure;

public class StockPriceRespository : IStockPriceRespository
{
    public IList<StockPrice> GetAll()
    {
        using (var context = new ApplicationDbContext())
        {
            var query = context.StockTrades
                .GroupBy(x => x.StockTicker, y => y.Price)
                .Select(x => new StockPrice(
                    x.Key,
                    x.Average(),
                    DateTime.Now));

            return query.ToList();
        }
    }

    public StockPrice GetByTicker(string stockTicker)
    {
        using (var context = new ApplicationDbContext())
        {
            var query = context.StockTrades
                .Where(x => x.StockTicker == stockTicker)
                .GroupBy(x => x.StockTicker, y => y.Price)
                .Select(x => new StockPrice(
                    x.Key,
                    x.Average(),
                    DateTime.Now));

            var stockPrice = query.SingleOrDefault();

            if (stockPrice is null)
            {
                throw new Exception("Test");
            }

            return stockPrice;
        }
    }
}