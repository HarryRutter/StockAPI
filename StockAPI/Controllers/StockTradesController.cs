using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure;
using StockAPI.Models;
using StockAPI.Models.DTOs;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockTradesController : ControllerBase
{
    private readonly ILogger<StockTradesController> _logger;
    private readonly ApplicationDbContext _applicationDbContext;

    public StockTradesController(ILogger<StockTradesController> logger, ApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStockTrade([FromBody] CreateStockTradeRequest request)
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

