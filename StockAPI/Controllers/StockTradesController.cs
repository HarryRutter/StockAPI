//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models;
using StockAPI.Models.DTOs;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
// Commenting this out for brevity but would need some auth checks to ensure the user making the request has a valid token and the rights to do so.
public class StockTradesController : ControllerBase
{
    private readonly IStockTradeRepository _stockTradeRepository;

    public StockTradesController(IStockTradeRepository stockTradeRepository)
    {
        _stockTradeRepository = stockTradeRepository;
    }

    [HttpPost]
    // Nice to get some rate limiting in here, save the server getting swamped under high traffic.
    public IActionResult CreateStockTrade([FromBody] CreateStockTradeRequest request)
    {
        try
        {
            StockTrade stockTrade = new(
            request.StockTicker,
            request.BrokerId, // Would be nice to get this from the broker's token directly perhaps?
            request.Price,
            request.NumberOfShares);

            // Move this off to a message queue for scalability.
            _stockTradeRepository.Create(stockTrade);

            return Ok();
        }
        catch (ArgumentException argumentEx)
        {
            // Would log this error but skipping for brevity.
            return BadRequest(argumentEx.Message);
        }
        catch (Exception ex)
        {
            // Log error but skipped for brevity.
            throw;
        }
    }
}

