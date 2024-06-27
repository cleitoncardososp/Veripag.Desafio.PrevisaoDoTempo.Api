using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Dtos.PrevisaoAtual;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Dtos.PrevisaoEstendida;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.WheatherApiService
{
    public interface IWeatherApiService
    {
        Task<PrevisaoAtualDto> ObterPrevisaoAtualAsync(string cidade);

        Task<PrevisaoEstendidaDto> ObterPrevisaoEstendida(string cidade);
    }
}
