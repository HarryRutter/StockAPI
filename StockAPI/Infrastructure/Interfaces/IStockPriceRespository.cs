using StockAPI.Models.DTOs;

namespace StockAPI.Infrastructure.Interfaces;

public interface IStockPriceRespository
{
	IList<StockPrice> GetAll();
	StockPrice GetByTicker(string stockTicker);
}

