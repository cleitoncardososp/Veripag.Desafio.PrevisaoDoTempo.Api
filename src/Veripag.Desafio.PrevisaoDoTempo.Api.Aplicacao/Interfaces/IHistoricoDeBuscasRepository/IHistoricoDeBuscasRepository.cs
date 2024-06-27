using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IHistoricoDeBuscasRepository
{
    public interface IHistoricoDeBuscasRepository
    {
        Task Salvar(HistoricoBusca historico);

        Task<List<HistoricoBusca>> ObterTodoHistorico();

        Task<PrevisaoAtual> ObterPrevisaoAtualAsync(string cidade);

        Task<List<PrevisaoEstendida>> ObterPrevisaoEstendidaAsync(string cidade);

        Task ExcluirHistoricoDeBuscas();
    }
}