namespace StockAPI.Models;

public class StockTrade
{
    public StockTrade(string stockTicker, Guid brokerId, decimal price, decimal numberOfShares)
    {
        Id = Guid.NewGuid();
        StockTicker = stockTicker?.ToUpper() ?? string.Empty;
        BrokerId = brokerId;
        Price = price;
        NumberOfShares = numberOfShares;
    }

    public Guid Id { get; init; }

    // In a full relational DB I'd have this be a navigation property to a full Stock model which would then link to these trades on a 1 to many.
    // For now, going to just have it here as there is nothing else to be persited relating to the Stock, it's just the ticker.
    public string StockTicker { get; private set; }

    public Guid BrokerId { get; private set; }

    // We only need to cater for GBP at the moment but to handle other currencies I'd convert to a custom Money type with currency and amount.
    public decimal Price { get; private set; }

    public decimal NumberOfShares { get; private set; }

    public void Validate()
    {
        // Throwing standard exceptions for now but might be nice to add some custom exception types.
        if (string.IsNullOrWhiteSpace(StockTicker))
        {
            throw new Exception("Stock ticker must be provided.");
        }

        if (Price <= 0)
        {
            throw new Exception("Price must be a decimal value greater than 0");
        }

        if (NumberOfShares <= 0)
        {
            throw new Exception("Number of shares must be a decimal value greater than 0.");
        }
    }
}



