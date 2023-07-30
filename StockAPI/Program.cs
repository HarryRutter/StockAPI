﻿using StockAPI.Infrastructure;
using StockAPI.Infrastructure.Interfaces;
using StockAPI.Services;
using StockAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStockTradeRepository, StockTradeRepository>();
builder.Services.AddScoped<IStockTradeService, StockTradeService>();
builder.Services.AddScoped<IStockPriceRespository, StockPriceRespository>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

