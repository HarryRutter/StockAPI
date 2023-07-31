using StockAPI.Models;

namespace StockAPI.Tests;

public class StockTradeTests
{
    [Fact]
    public void Entity_Should_Create_WithUpperCaseStockTicker()
    {
        // Arrange


        // Act
        StockTrade stockTrade = new(
            "test",
            Guid.NewGuid(),
            100,
            10);

        // Assert
        Assert.Equal("TEST", stockTrade.StockTicker);
    }

    [Fact]
    public void Entity_ShouldNot_Create_WithMissingStockTicker()
    {
        // Arrange

        // Act
        try
        {
            StockTrade stockTrade = new(
              string.Empty,
              Guid.NewGuid(),
              100,
              10);

            Assert.Fail();
        }
        catch (ArgumentException expectedException)
        {
            // Expected exception thrown.
            // I'd like to throw a custom exception here or maybe a enum, to save checking for a string which is not great but don't have time sadly.
            // Assert
            Assert.Equal("Stock ticker must be provided.", expectedException.Message);
        }
    }

    [Fact]
    public void Entity_ShouldNot_Create_WithNegativePrice()
    {
        // Arrange

        // Act
        try
        {
            StockTrade stockTrade = new(
              "TEST",
              Guid.NewGuid(),
              -100,
              10);

            Assert.Fail();
        }
        catch (ArgumentException expectedException)
        {
            // Expected exception thrown.
            // I'd like to throw a custom exception here or maybe a enum, to save checking for a string which is not great but don't have time sadly.
            // Assert
            Assert.Equal("Price must be a decimal value greater than 0.", expectedException.Message);
        }
    }

    [Fact]
    public void Entity_ShouldNot_Create_WithNegativeNumberOfShares()
    {
        // Arrange

        // Act
        try
        {
            StockTrade stockTrade = new(
              "TEST",
              Guid.NewGuid(),
              100,
              -10);

            Assert.Fail();
        }
        catch (ArgumentException expectedException)
        {
            // Expected exception thrown.
            // I'd like to throw a custom exception here or maybe a enum, to save checking for a string which is not great but don't have time sadly.
            // Assert
            Assert.Equal("Number of shares must be a decimal value greater than 0.", expectedException.Message);
        }
    }
}

