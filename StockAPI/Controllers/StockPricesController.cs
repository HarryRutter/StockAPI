using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure.Interfaces;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockPricesController : ControllerBase
{
    private readonly IStockPriceRespository _stockPriceRespository;

    public StockPricesController(IStockPriceRespository stockTradeRespository)
    {
        _stockPriceRespository = stockTradeRespository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var results = _stockPriceRespository.GetAll();
        return Ok(results);
    }

    [HttpGet("GetByTicker")]
    public IActionResult GetByTicker(string stockTicker)
    {
        var result = _stockPriceRespository.GetByTicker(stockTicker);
        return Ok(result);
    }

    // To-Do
    //[HttpGet("GetByTickers")]
    //public IActionResult GetByTickerList([rams string tickers)
    //{
    //    var result = _applicationDbContext.StockTrades
    //        .Where(x => x.StockTicker == stockTicker)
    //        .GroupBy(x => x.StockTicker, y => y.Price)
    //        .Select(x => new StockPrice(x.Key, x.Average()));

    //    return Ok(result);
    //}

    //We need to expose the current value of a stock,
    //    values for all the stocks on the market
    //    and values for a range of them(as a list of ticker symbols).
}

