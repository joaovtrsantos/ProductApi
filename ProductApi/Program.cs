using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure.Context;
using ProductApi.Models.Interfaces;
using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseInMemoryDatabase("ProductList")
);

builder.Services.AddScoped<ICreateProductService, CreateProductService>();
builder.Services.AddScoped<IUpdateProductService, UpdateProductService>();
builder.Services.AddScoped<IDeleteProductService, DeleteProductService>();
builder.Services.AddScoped<IGetProductByIdService, GetProductByIdService>();
builder.Services.AddScoped<IGetProductsService, GetProductsService>();

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
