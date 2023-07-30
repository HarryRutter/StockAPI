using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;
using StockAPI.Models.DTOs;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockTradesController : ControllerBase
{
    private readonly IStockTradeRepository _stockTradeRespository;

    public StockTradesController(IStockTradeRepository stockTradeRespository)
    {
        _stockTradeRespository = stockTradeRespository;
    }

    [HttpPost]
    public IActionResult CreateStockTrade([FromBody] CreateStockTradeRequest request)
    {
        StockTrade stockTrade = new(
            request.StockTicker,
            request.BrokerId,
            request.Price,
            request.NumberOfShares);

        _stockTradeRespository.Create(stockTrade);

        return Ok();
    }
}

