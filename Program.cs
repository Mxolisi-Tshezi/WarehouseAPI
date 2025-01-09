using BusinessLayer.Logic.Orders;
using BusinessLayer.Logic.Products;
using BusinessLayer.Logic.Warehouses;
using DataLayer.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WarehouseAPI.Services.Orders;
using WarehouseAPI.Services.Products;
using WarehouseAPI.Services.Warehouses;

var builder = WebApplication.CreateBuilder(args);
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<OrderBL>();
builder.Services.AddScoped<ProductBL>();
builder.Services.AddScoped<WarehousesBL>();

builder.Services.AddDbContext<WarehouseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseConnection")));

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