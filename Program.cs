using POSsystem.Services;
using Microsoft.EntityFrameworkCore;
using POSsystem.Data;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICatagoryService, CatagoryService>();
builder.Services.AddScoped<IIngredientUnitService, IngredientUnitService>();
builder.Services.AddOpenApi();
// Register POSDbContext scoped for incoming HTTP requests
builder.Services.AddDbContext<POSDbContext>(options =>options.UseNpgsql(builder.Configuration.GetConnectionString("TmsDatabase")));
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.MapControllers();
app.Run();

