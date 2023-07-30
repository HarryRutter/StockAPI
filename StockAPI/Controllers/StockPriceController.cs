using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure;
using StockAPI.Models.DTOs;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockPriceController : ControllerBase
{
    private readonly ILogger<StockTradeController> _logger;
    private readonly ApplicationDbContext _applicationDbContext;

    public StockPriceController(ILogger<StockTradeController> logger, ApplicationDbContext applicationDbContext)
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
 
    //We need to expose the current value of a stock,
    //    values for all the stocks on the market
    //    and values for a range of them(as a list of ticker symbols).
}

