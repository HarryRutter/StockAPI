using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models.DTOs;

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

    [HttpPost("GetByTickerList")]
    public IActionResult GetByTickerList(GetStockPricesByTickerListRequest request)
    {
        var result = _stockPriceRespository.GetByTickerList(request.stockTickers);
        return Ok(result);
    }
}

