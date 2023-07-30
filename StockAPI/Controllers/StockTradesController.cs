using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;
using StockAPI.Models.DTOs;
using StockAPI.Services.Interfaces;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockTradesController : ControllerBase
{
    private readonly IStockTradeService _stockTradeService;

    public StockTradesController(IStockTradeService stockTradeService)
    {
        _stockTradeService = stockTradeService;
    }

    [HttpPost]
    public IActionResult CreateStockTrade([FromBody] CreateStockTradeRequest request)
    {
        StockTrade stockTrade = new(
            request.StockTicker,
            request.BrokerId,
            request.Price,
            request.NumberOfShares);

        try
        {
            // Would be nice to have this all wrapped in a MediatR command handler or something but I didn't have the time.
            _stockTradeService.CreateIfValid(stockTrade);

            // Should probaby return Created() with URL to Get the generated record but we don't use the price record itself yet.
            return Ok();
        }
        // If threw custom validation messages, could check for each and return different response code.
        // For now just catching and throwing.
        catch { 
            throw;
        }            
    }
}

