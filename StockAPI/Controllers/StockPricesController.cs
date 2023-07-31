﻿//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockAPI.Infrastructure.Interfaces;
using StockAPI.Models.DTOs;

namespace StockAPI.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
// Commenting this out for brevity but would need some auth checks to ensure the user making the request has a valid token and the rights to do so.
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
        IList<StockPriceResponse> results = _stockPriceRespository.GetAll();

        return Ok(results);
    }

    [HttpGet("GetByTicker")]
    public IActionResult GetByTicker(string stockTicker)
    {
        try
        {
            StockPriceResponse result = _stockPriceRespository.GetByTicker(stockTicker);

            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }       
    }

    [HttpPost("GetByTickerList")]
    public IActionResult GetByTickerList(GetStockPricesByTickerListRequest request)
    {
        IList<StockPriceResponse> result = _stockPriceRespository.GetByTickerList(request.stockTickers);

        return Ok(result);
    }
}

