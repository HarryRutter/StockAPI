using StockAPI.Models;

namespace StockAPI.Services.Interfaces;

public interface IStockTradeService
{
	void CreateIfValid(StockTrade stockTrade);
}

