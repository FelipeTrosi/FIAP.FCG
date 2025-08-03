using FIAP.FCG.API.Extensions;
using FIAP.FCG.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#region -- Data

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Scoped);

#endregion

#region -- JWT

builder.Services.UseJwtAuthentication(builder.Configuration);

#endregion

#region -- DI

builder.Services.AddCorrelationIdGenerator();
builder.Services.AddRepositoryDI();
builder.Services.AddServiceDI();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region -- Middleware

app.UseCorrelationMiddleware();
app.UseLogMiddleware();
app.UseGlobalExceptionHandler();

#endregion

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
