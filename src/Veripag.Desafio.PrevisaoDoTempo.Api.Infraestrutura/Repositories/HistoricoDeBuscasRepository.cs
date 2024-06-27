using Microsoft.EntityFrameworkCore;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IHistoricoDeBuscasRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.Enums;
using Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Context;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Repositories
{
    public class HistoricoDeBuscasRepository : IHistoricoDeBuscasRepository
    {
        private readonly PrevisaoDoTempoContext _context;

        public HistoricoDeBuscasRepository(PrevisaoDoTempoContext context)
        {
            _context = context;
        }

        public async Task Salvar(HistoricoBusca historico)
        {
            await _context.HistoricoDeBuscas.AddAsync(historico);
            await _context.SaveChangesAsync();
        }

        public async Task<List<HistoricoBusca>> ObterTodoHistorico()
        {
            return await _context.HistoricoDeBuscas
                .OrderByDescending(x => x.DataBusca)
                .ToListAsync();
        }

        public async Task ExcluirHistoricoDeBuscas()
        {
            await _context.HistoricoDeBuscas.ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<PrevisaoAtual> ObterPrevisaoAtualAsync(string cidade)
        {
            HistoricoBusca? historico = await _context.HistoricoDeBuscas
                .Where(x => x.CidadePesquisada == cidade && x.TipoPrevisao == TipoPrevisao.ATUAL)
                .FirstOrDefaultAsync();

            if (historico == null)
                return null;

            return await _context.PrevisaoAtual.Where(x => x.HistoricoBuscaId == historico.Id).FirstOrDefaultAsync();
        }

        public async Task<List<PrevisaoEstendida>> ObterPrevisaoEstendidaAsync(string cidade)
        {
            HistoricoBusca? historico = await _context.HistoricoDeBuscas
                .Where(x => x.CidadePesquisada == cidade && x.TipoPrevisao == TipoPrevisao.ESTENDIDA)
                .FirstOrDefaultAsync();

            if (historico == null)
                return null;

            return await _context.PrevisaoEstendidas.Where(x => x.HistoricoBuscaId == historico.Id).ToListAsync();
        }
    }
}
