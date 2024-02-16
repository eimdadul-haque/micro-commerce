using Catalog.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication
    .CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers();

builder.Services
    .AddSwaggerGen();

builder.Services
    .AddDbContext<CatalogDbContext>(option => option
    .UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerUI(options
    => options.SwaggerEndpoint("v1/swagger.json", "v1"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.Run();
