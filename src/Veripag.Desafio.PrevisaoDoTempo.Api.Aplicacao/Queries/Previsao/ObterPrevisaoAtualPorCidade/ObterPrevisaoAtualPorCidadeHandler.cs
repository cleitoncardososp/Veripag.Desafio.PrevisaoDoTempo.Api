using MediatR;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IHistoricoDeBuscasRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IPrevisaoAtualRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.WheatherApiService;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.Enums;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Previsao.ObterPrevisaoAtualPorCidade
{
    public class ObterPrevisaoAtualPorCidadeHandler : IRequestHandler<ObterPrevisaoAtualPorCidadeQuery, ObterPrevisaoAtualPorCidadeResponse>
    {
        private readonly IWeatherApiService _weatherApiService;
        private readonly IHistoricoDeBuscasRepository _historicoDeBuscasRepository;
        private readonly IPrevisaoAtualRepository _previsaoAtualRepository;

        public ObterPrevisaoAtualPorCidadeHandler(IWeatherApiService wheatherApiService, IHistoricoDeBuscasRepository historicoDeBuscas = null, IPrevisaoAtualRepository previsaoAtualRepository = null)
        {
            _weatherApiService = wheatherApiService;
            _historicoDeBuscasRepository = historicoDeBuscas;
            _previsaoAtualRepository = previsaoAtualRepository;
        }

        public async Task<ObterPrevisaoAtualPorCidadeResponse> Handle(ObterPrevisaoAtualPorCidadeQuery request, CancellationToken cancellationToken)
        {
            PrevisaoAtual previsaoCache = await _historicoDeBuscasRepository.ObterPrevisaoAtualAsync(request.Cidade);

            if (previsaoCache != null)
            {
                return new ObterPrevisaoAtualPorCidadeResponse()
                {
                    Temperatura = previsaoCache.Temperatura,
                    Umidade = previsaoCache.Umidade,
                    DescricaoTempo = previsaoCache.DescricaoTempo,
                    VelocidadeVento = previsaoCache.VelocidadeVento
                };
            }

            var previsao = await _weatherApiService.ObterPrevisaoAtualAsync(request.Cidade);

            if (previsao.current == null)
                return null;

            HistoricoBusca historico = new HistoricoBusca(request.Cidade, TipoPrevisao.ATUAL);
            await _historicoDeBuscasRepository.Salvar(historico);

            PrevisaoAtual previsaoAtual = new PrevisaoAtual(
                previsao.current.temp_c,
                previsao.current.humidity,
                previsao.current.condition.text,
                previsao.current.wind_kph,
                historico.Id);
            await _previsaoAtualRepository.Salvar(previsaoAtual);

            return new ObterPrevisaoAtualPorCidadeResponse()
            {
                Temperatura = previsao.current.temp_c,
                Umidade = previsao.current.humidity,
                DescricaoTempo = previsao.current.condition.text,
                VelocidadeVento = previsao.current.wind_kph
            };
        }
    }
}
