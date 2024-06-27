using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AdicionarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = Assembly.GetExecutingAssembly().GetName().Name,
                    Description = "Teste tecnico Veripag.",
                    Contact = new OpenApiContact
                    {
                        Name = "Cleiton Cardoso",
                        Url = new Uri("https://www.linkedin.com/in/cleiton-cardoso/")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return services;
        }
    }
}