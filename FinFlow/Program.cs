using System.Security.Cryptography.X509Certificates;
using FinFlow.Data;
using FinFlow.Dtos;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FinFlowContext>(options=>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.MigrateDatabase();
app.MapCustomerEndpoints();

app.MapAccountEndpoints();
app.MapTransactionEndpoints();

app.Run();

