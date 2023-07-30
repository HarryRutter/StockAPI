using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;
using StockAPI.Models.DTOs;

namespace StockAPI.Infrastructure;

public class StockPriceRespository : IStockPriceRespository
{
    public StockPriceRespository()
    {
        // Init seed data
        List<StockTrade> stockTrades = new()
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
                20),
            new StockTrade(
                "META",
                Guid.NewGuid(),
                0.01m,
                1000)
        };

        using (ApplicationDbContext context = new())
        {
            context.StockTrades.AddRange(stockTrades);
            context.SaveChanges();
        };
    }

    public IList<StockPriceResponse> GetAll()
    {
        using (ApplicationDbContext context = new())
        {
            IQueryable<StockPriceResponse> query = context.StockTrades
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
        using (ApplicationDbContext context = new())
        {
            IQueryable<StockPriceResponse> query = context.StockTrades
                .Where(x => x.StockTicker == stockTicker)
                .GroupBy(x => x.StockTicker, y => y.Price)
                .Select(x => new StockPriceResponse(
                    x.Key,
                    x.Average(),
                    DateTime.Now));

            StockPriceResponse stockPrice = query.SingleOrDefault();

            if (stockPrice is null)
            {
                throw new Exception("Test");
            }

            return stockPrice;
        }
    }

    public IList<StockPriceResponse> GetByTickerList(IList<string> stockTickers)
    {
        using (ApplicationDbContext context = new())
        {
            IQueryable<StockPriceResponse> query = context.StockTrades
                .Where(x => stockTickers.Contains(x.StockTicker))
                .GroupBy(x => x.StockTicker, y => y.Price)
                .Select(x => new StockPriceResponse(
                    x.Key,
                    x.Average(),
                    DateTime.Now));

            return query.ToList();
        }
    }
}