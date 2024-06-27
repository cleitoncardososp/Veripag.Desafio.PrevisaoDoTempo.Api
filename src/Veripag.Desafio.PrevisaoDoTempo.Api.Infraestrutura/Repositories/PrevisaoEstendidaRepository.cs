using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IPrevisaoEstendidaRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;
using Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Context;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Repositories
{
    public class PrevisaoEstendidaRepository : IPrevisaoEstendidaRepository
    {
        private readonly PrevisaoDoTempoContext _context;

        public PrevisaoEstendidaRepository(PrevisaoDoTempoContext context)
        {
            _context = context;
        }

        public async Task Salvar(PrevisaoEstendida previsaoEstendida)
        {
            await _context.PrevisaoEstendidas.AddAsync(previsaoEstendida);
            await _context.SaveChangesAsync();
        }
    }
}
