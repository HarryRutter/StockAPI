
namespace StockAPI.Models.DTOs;

public record GetStockPricesByTickerListRequest(
    List<string> stockTickers);

