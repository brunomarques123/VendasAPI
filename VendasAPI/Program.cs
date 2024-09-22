using Serilog; // Adicione esta linha
using Microsoft.OpenApi.Models; // Para Swagger e OpenAPI
using Microsoft.EntityFrameworkCore;
using VendasAPI.Data.Context;
using VendasAPI.Data.Repositories;
using VendasAPI.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Logs no console
    .WriteTo.File("logs/app_log.txt", rollingInterval: RollingInterval.Day) // Logs em arquivo
    .CreateLogger();

// Adicionar o Serilog ao builder
builder.Host.UseSerilog(); // Usar Serilog como o logger padrão

// Add services to the container.
builder.Services.AddDbContext<VendasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<VendaService>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vendas API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vendas API V1");
    });
}

// Middleware para registrar logs de requisições HTTP
app.UseSerilogRequestLogging(); // Adiciona logs automáticos para requisições HTTP

app.UseHttpsRedirection();



app.MapControllers();
app.Run();
