using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure;
using StockAPI.Models.DTOs;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockPricesController : ControllerBase
{
    private readonly ILogger<StockTradesController> _logger;
    private readonly ApplicationDbContext _applicationDbContext;

    public StockPricesController(ILogger<StockTradesController> logger, ApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet]
    public IActionResult GetAllStockPrices()
    {
        var results = _applicationDbContext.StockTrades
            .GroupBy(x => x.StockTicker, y => y.Price)
            .Select(x => new StockPrice(x.Key, x.Average()));

        return Ok(results);
    }

    [HttpGet("GetByTicker")]
    public IActionResult GetStockPriceByTicker(string stockTicker)
    {
        var result = _applicationDbContext.StockTrades
            .Where(x => x.StockTicker == stockTicker)
            .GroupBy(x => x.StockTicker, y => y.Price)
            .Select(x => new StockPrice(x.Key, x.Average()));

        return Ok(result);
    }

    // To-Do
    //[HttpGet("GetByTickers")]
    //public IActionResult GetStockPricesByTickerList([rams string tickers)
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

