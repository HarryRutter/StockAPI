using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;
using StockAPI.Models.DTOs;

namespace StockAPI.Infrastructure;

public class StockPriceRespository : IStockPriceRespository
{
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
                throw new KeyNotFoundException($"No price found for {stockTicker}.");
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