using AmvoxStock.Api.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Configurações adicionais e Serilog (comentado)
// builder.Host.UseSerilog((_, config) =>
// {
//     config.WriteTo.Console()
//         .ReadFrom.Configuration(builder.Configuration);
// });

builder.Host.AddConfigurations();

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructure(builder.Configuration);
// builder.Services.AddApplication();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Outros middlewares
// app.UseInfrastructure(builder.Configuration);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
