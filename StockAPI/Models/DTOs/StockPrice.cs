namespace StockAPI.Models.DTOs;

public record StockPrice(
    string StockTicker,
    decimal CurrentPrice);