using Microsoft.EntityFrameworkCore;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Context
{
    public class PrevisaoDoTempoContext : DbContext
    {
        public DbSet<HistoricoBusca> HistoricoDeBuscas { get; set; }
        public DbSet<PrevisaoAtual> PrevisaoAtual { get; set; }
        public DbSet<PrevisaoEstendida> PrevisaoEstendidas { get; set; }

        public PrevisaoDoTempoContext(DbContextOptions<PrevisaoDoTempoContext> options) : base(options)
        {
        }
    }
}
