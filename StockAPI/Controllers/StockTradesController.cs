﻿using Microsoft.AspNetCore.Mvc;
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

        try
        {
            // Validate method will throw exception if business rules aren't satisfied.
            stockTrade.Validate();

            // If no exceptions, ok to create.
            _stockTradeRespository.Create(stockTrade);

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

