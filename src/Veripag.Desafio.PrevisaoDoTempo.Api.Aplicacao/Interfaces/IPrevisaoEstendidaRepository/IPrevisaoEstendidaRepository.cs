using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IPrevisaoEstendidaRepository
{
    public interface IPrevisaoEstendidaRepository
    {
        Task Salvar(PrevisaoEstendida previsaoEstendida);
    }
}
