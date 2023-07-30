namespace StockAPI.Models.Commands;

public record CreateStockTradeRequest(
    string StockTicker,
    Guid BrokerId,
    decimal Price,
    decimal NumberOfShares);