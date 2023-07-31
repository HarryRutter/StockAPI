//using Microsoft.AspNetCore.Authorization;
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
        catch (ArgumentNullException argumentNullEx)
        {
            return BadRequest(argumentNullEx.Message);
        }
        catch (KeyNotFoundException keyNotFoundEx)
        {
            return NotFound(keyNotFoundEx.Message);
        }
        catch (Exception ex)
        {
            // Log error but skipped for brevity.
            throw;
        }
    }

    [HttpPost("GetByTickerList")]
    public IActionResult GetByTickerList(GetStockPricesByTickerListRequest request)
    {
        try
        {
            IList<StockPriceResponse> result = _stockPriceRespository.GetByTickerList(request.StockTickers);

            return Ok(result);
        }
        catch (ArgumentNullException argumentNullEx)
        {
            return BadRequest(argumentNullEx.Message);
        }
        catch (Exception ex)
        {
            // Log error but skipped for brevity.
            throw;
        }
    }
}

