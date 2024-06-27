using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IHistoricoDeBuscasRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IPrevisaoAtualRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IPrevisaoEstendidaRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.WheatherApiService;
using Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Repositories;
using Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Services.WheatherApiService;
using Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Services.ExcluirHistoricoDeBuscaService;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AdicionarDependencias(this IServiceCollection services)
        {
            InjetarInterfaces(services);
            InjetarBackgroundServices(services);

            return services;
        }


        private static void InjetarInterfaces(IServiceCollection services)
        {
            services.AddScoped<IHistoricoDeBuscasRepository, HistoricoDeBuscasRepository>();
            services.AddScoped<IPrevisaoAtualRepository, PrevisaoAtualRepository>();
            services.AddScoped<IPrevisaoEstendidaRepository, PrevisaoEstendidaRepository>();
            services.AddScoped<IWeatherApiService, WeatherApiService>();
        }

        private static void InjetarBackgroundServices(IServiceCollection services)
        {
            services.AddHostedService<ExcluirHistoricoDeBuscaService>();
        }
    }
}