using Microsoft.EntityFrameworkCore;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IPrevisaoAtualRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;
using Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Context;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Repositories
{
    public class PrevisaoAtualRepository : IPrevisaoAtualRepository
    {
        private readonly PrevisaoDoTempoContext _context;

        public PrevisaoAtualRepository(PrevisaoDoTempoContext context)
        {
            _context = context;
        }

        public async Task Salvar(PrevisaoAtual previsaoAtual)
        {
            await _context.PrevisaoAtual.AddAsync(previsaoAtual);
            await _context.SaveChangesAsync();
        }
    }
}
