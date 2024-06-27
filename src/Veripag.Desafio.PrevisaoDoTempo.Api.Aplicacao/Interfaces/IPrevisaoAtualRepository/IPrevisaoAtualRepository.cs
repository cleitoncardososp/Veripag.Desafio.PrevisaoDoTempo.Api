using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IPrevisaoAtualRepository
{
    public interface IPrevisaoAtualRepository
    {
        Task Salvar(PrevisaoAtual previsaoAtual);
    }
}
