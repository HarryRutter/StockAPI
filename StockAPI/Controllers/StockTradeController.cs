using Microsoft.AspNetCore.Mvc;
using StockAPI.Models;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StockTradeController : ControllerBase
{
    private readonly ILogger<StockTradeController> _logger;

    public StockTradeController(ILogger<StockTradeController> logger)
    {
        _logger = logger;
    }
}

