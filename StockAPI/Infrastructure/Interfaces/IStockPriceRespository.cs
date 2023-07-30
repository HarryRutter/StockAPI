using StockAPI.Models.DTOs;

namespace StockAPI.Infrastructure.Interfaces;

public interface IStockPriceRespository
{
	IList<StockPriceResponse> GetAll();

	StockPriceResponse GetByTicker(string stockTicker);

	IList<StockPriceResponse> GetByTickerList(IList<string> stockTickers);
}

