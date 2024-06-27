using System.Text.Json.Serialization;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection AdicionarConfiguracoesApi(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddControllers().AddJsonOptions(options => 
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}
