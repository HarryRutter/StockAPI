namespace StockAPI.Models.DTOs;

public record StockPriceResponse(
    string StockTicker,
    decimal Price,
    DateTime PriceDateTime);