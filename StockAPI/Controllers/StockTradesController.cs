using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure;
using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;
using StockAPI.Models.DTOs;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockTradesController : ControllerBase
{
    private readonly IStockTradeRepository _stockTradeRepository;

    public StockTradesController(IStockTradeRepository stockTradeRepository)
    {
        _stockTradeRepository = stockTradeRepository;
    }

    [HttpPost]
    public IActionResult CreateStockTrade([FromBody] CreateStockTradeRequest request)
    {
        StockTrade stockTrade = new(
            request.StockTicker,
            request.BrokerId,
            request.Price,
            request.NumberOfShares);

        // Create will only create if valid.
        _stockTradeRepository.Create(stockTrade);

        return Ok();
    }
}

