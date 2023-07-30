namespace StockAPI.Models;

public class StockTrade
{
    public StockTrade(string stockTicker, Guid brokerId, decimal price, decimal numberOfShares)
    {
        Id = Guid.NewGuid();
        StockTicker = stockTicker;
        BrokerId = brokerId;
        Price = price;
        NumberOfShares = numberOfShares;
    }

    public Guid Id { get; set; }

    // In a full relation DB I'd have this be a navigation property to a full Stock model which would then link to these traces on a 1 to many.
    // For now, going to just have it here as there is nothing else to be persited relating to the Stock.
    public string StockTicker { get; set; }

    public Guid BrokerId { get; set; }

    // We only need to cater for GBP at the moment.
    // To handle other currencies I'd convert to a custom Money type with currency and amount.
    public decimal Price { get; set; }

    public decimal NumberOfShares { get; set; }
}



