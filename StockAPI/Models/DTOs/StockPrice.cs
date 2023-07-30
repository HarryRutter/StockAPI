namespace StockAPI.Models.DTOs;

public record StockPrice(
    string StockTicker,
    decimal Price,
    DateTime PriceDateTime);