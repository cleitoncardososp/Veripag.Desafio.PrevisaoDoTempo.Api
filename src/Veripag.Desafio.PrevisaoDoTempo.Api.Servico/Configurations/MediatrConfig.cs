namespace Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Configurations
{
    public static class MediatrConfig
    {
        public static IServiceCollection AdicionarMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao")));

            return services;
        }
    }
}
