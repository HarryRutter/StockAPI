# StockAPI
Stock API Project for Tyl by Harry Rutter

## Introduction

The intent of this project is to offer up a few API services - one to add records for stock trades then some to query by all, ticker and list of tickers.

## Notes

My thinking was that we only really need to persist the trades themselves and can then derive the average prices when we query, so we only have one DB entity and then a few DTOs.

Added some basic unit tests for the StockTrade object but didn't get round to the repository tests sadly.

There's a few other commented areas dotted around the project with things I would have liked to have done with more time but this should work for now!

Thanks, I look forward to hearing your feedback!