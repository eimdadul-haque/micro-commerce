using Catalog.Application.Products;
using Catalog.Infrastructure;
using Catalog.Share.Products.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CatalogDbContext>(option => option
    .UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
});

app.Run();
