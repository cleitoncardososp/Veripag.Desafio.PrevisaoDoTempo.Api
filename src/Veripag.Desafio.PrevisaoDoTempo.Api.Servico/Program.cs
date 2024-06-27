using Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Configurations;

if (Environment.GetEnvironmentVariable("WeatherApi_Key") == null)
{
    Console.WriteLine("NECESSÁRIO CONFIGURAR A CHAVE DA WEATHERAPI NAS VARIAVEIS DE AMBIENTE!");
    Console.WriteLine("WeatherApi_Key:TOKEN");
    return;
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AdicionarMediatr();
builder.Services.AdicionarDbContext(builder.Configuration);
builder.Services.AdicionarDependencias();
builder.Services.AdicionarConfiguracoesApi();
builder.Services.AdicionarSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
