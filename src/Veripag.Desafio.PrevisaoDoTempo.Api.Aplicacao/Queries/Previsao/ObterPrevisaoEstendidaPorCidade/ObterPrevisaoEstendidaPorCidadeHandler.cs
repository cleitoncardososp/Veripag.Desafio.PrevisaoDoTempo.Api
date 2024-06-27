using MediatR;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IHistoricoDeBuscasRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IPrevisaoEstendidaRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.WheatherApiService;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.Enums;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Previsao.ObterPrevisaoEstendidaPorCidade
{
    public class ObterPrevisaoEstendidaPorCidadeHandler : IRequestHandler<ObterPrevisaoEstendidaPorCidadeQuery, List<ObterPrevisaoEstendidaPorCidadeResponse>>
    {
        private readonly IWeatherApiService _weatherApiService;
        private readonly IHistoricoDeBuscasRepository _historicoDeBuscas;
        private readonly IPrevisaoEstendidaRepository _previsaoEstendidaRepository;

        public ObterPrevisaoEstendidaPorCidadeHandler(IWeatherApiService weatherApiService, IHistoricoDeBuscasRepository historicoDeBuscas = null, IPrevisaoEstendidaRepository previsaoEstendidaRepository = null)
        {
            _weatherApiService = weatherApiService;
            _historicoDeBuscas = historicoDeBuscas;
            _previsaoEstendidaRepository = previsaoEstendidaRepository;
        }

        public async Task<List<ObterPrevisaoEstendidaPorCidadeResponse>> Handle(ObterPrevisaoEstendidaPorCidadeQuery request, CancellationToken cancellationToken)
        {
            List<PrevisaoEstendida> listaPrevisaoCache = await _historicoDeBuscas.ObterPrevisaoEstendidaAsync(request.Cidade);

            List<ObterPrevisaoEstendidaPorCidadeResponse> lista = new();

            if (listaPrevisaoCache != null)
            {
                for (int i = 0; i < listaPrevisaoCache.Count; i++)
                {
                    lista.Add
                    (
                        new ObterPrevisaoEstendidaPorCidadeResponse()
                        {
                            Data = listaPrevisaoCache[i].Dia,
                            Temperatura = listaPrevisaoCache[i].Temperatura,
                            Umidade = listaPrevisaoCache[i].Umidade,
                            DescricaoTempo = listaPrevisaoCache[i].DescricaoTempo,
                            VelocidadeVento = listaPrevisaoCache[i].VelocidadeVento
                        }
                    );
                }

                return lista;
            }

            var previsao = await _weatherApiService.ObterPrevisaoEstendida(request.Cidade);

            if (previsao.current == null)
                return null;

            HistoricoBusca historico = new HistoricoBusca(request.Cidade, TipoPrevisao.ESTENDIDA);
            await _historicoDeBuscas.Salvar(historico);

            for (int i = 0; i < previsao.forecast.forecastday.Count; i++)
            {
                lista.Add
                (
                    new ObterPrevisaoEstendidaPorCidadeResponse()
                    {
                        Data = previsao.forecast.forecastday[i].date,
                        Temperatura = previsao.forecast.forecastday[i].day.avgtemp_c,
                        Umidade = previsao.forecast.forecastday[i].day.avghumidity,
                        DescricaoTempo = previsao.forecast.forecastday[i].day.condition.text,
                        VelocidadeVento = previsao.forecast.forecastday[i].day.maxwind_kph
                    }
                );

                PrevisaoEstendida previsaoEstendida = new PrevisaoEstendida(
                    previsao.forecast.forecastday[i].date,
                    previsao.forecast.forecastday[i].day.avgtemp_c,
                    previsao.forecast.forecastday[i].day.avghumidity,
                    previsao.forecast.forecastday[i].day.condition.text,
                    previsao.forecast.forecastday[i].day.maxwind_kph,
                    historico.Id);

                await _previsaoEstendidaRepository.Salvar(previsaoEstendida);
            }

            return lista;
        }
    }
}