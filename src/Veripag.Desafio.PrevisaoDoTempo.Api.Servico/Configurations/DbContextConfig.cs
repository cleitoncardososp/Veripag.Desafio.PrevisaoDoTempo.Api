using Microsoft.EntityFrameworkCore;
using Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Context;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Configurations
{
    public static class DbContextConfig
    {
        public static IServiceCollection AdicionarDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PrevisaoDoTempoContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("VeripagPrevisaoDoTempoConnection"),
            x => x.MigrationsHistoryTable("__PrevisaoDoTempoMigrationsHistoryTable")));

            return services;
        }
    }
}
