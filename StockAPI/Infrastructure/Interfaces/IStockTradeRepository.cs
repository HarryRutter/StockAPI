using StockAPI.Models;

namespace StockAPI.Infrastructure.Interfaces;

public interface IStockTradeRepository
{
    void Create(StockTrade stockTrade);
}

