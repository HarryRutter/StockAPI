using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;
using StockAPI.Models.DTOs;

namespace StockAPI.Infrastructure;

public class StockPriceRespository : IStockPriceRespository
{
    public StockPriceRespository()
    {
        // Init seed data
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

    public IList<StockPriceResponse> GetAll()
    {
        using (var context = new ApplicationDbContext())
        {
            var query = context.StockTrades
                .GroupBy(x => x.StockTicker, y => y.Price)
                .Select(x => new StockPriceResponse(
                    x.Key,
                    x.Average(),
                    DateTime.Now));

            return query.ToList();
        }
    }

    public StockPriceResponse GetByTicker(string stockTicker)
    {
        using (var context = new ApplicationDbContext())
        {
            var query = context.StockTrades
                .Where(x => x.StockTicker == stockTicker)
                .GroupBy(x => x.StockTicker, y => y.Price)
                .Select(x => new StockPriceResponse(
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