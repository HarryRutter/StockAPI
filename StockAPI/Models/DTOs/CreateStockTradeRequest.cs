namespace StockAPI.Models.DTOs;

public record CreateStockTradeRequest(
    string StockTicker,
    Guid BrokerId,
    decimal Price,
    decimal NumberOfShares);