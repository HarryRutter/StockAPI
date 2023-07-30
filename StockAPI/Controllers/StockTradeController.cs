using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure;
using StockAPI.Models;
using StockAPI.Models.Commands;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockTradeController : ControllerBase
{
    private readonly ILogger<StockTradeController> _logger;
    private readonly ApplicationDbContext _applicationDbContext;

    public StockTradeController(ILogger<StockTradeController> logger, ApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _applicationDbContext = applicationDbContext;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateStockTrade([FromBody] CreateStockTradeCommand request)
    {
        StockTrade stockTrade = new (
            request.StockTicker,
            request.BrokerId,
            request.Price,
            request.NumberOfShares);

        _applicationDbContext.Add(stockTrade);
        await _applicationDbContext.SaveChangesAsync();

        return Ok();
    }

    //We need to expose the current value of a stock,
    //    values for all the stocks on the market
    //    and values for a range of them(as a list of ticker symbols).
}

