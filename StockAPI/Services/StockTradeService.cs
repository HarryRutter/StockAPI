using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;
using StockAPI.Services.Interfaces;

namespace StockAPI.Services;

public class StockTradeService : IStockTradeService
{
    private readonly IStockTradeRepository _stockTradeRespository;

    public StockTradeService(IStockTradeRepository stockTradeRespository)
    {
        _stockTradeRespository = stockTradeRespository;
    }

    public void CreateIfValid(StockTrade stockTrade)
	{
        try
        {
            // Validate method will throw exception if business rules aren't satisfied.
            stockTrade.Validate();

            // If no exceptions, ok to create.
            _stockTradeRespository.Create(stockTrade);         
        }
        // If threw custom validation messages, could check for each and return different response code.
        // For now just catching and throwing.
        catch
        {
            throw;
        }
    }
}

