using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Dtos.PrevisaoAtual;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Dtos.PrevisaoEstendida;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.WheatherApiService;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Infraestrutura.Services.WheatherApiService
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        const int DIAS_PREVISAO = 6;
        const string BASE_ADDRESS = "https://api.weatherapi.com/v1";
        string KEY = Environment.GetEnvironmentVariable("WeatherApi_Key");

        public WeatherApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<PrevisaoAtualDto> ObterPrevisaoAtualAsync(string cidade)
        {
            var client = _httpClientFactory.CreateClient("client");
            var response = await client.GetAsync(BASE_ADDRESS + $"/current.json?q={cidade}&key={KEY}");

            verificarStatusCodeResponse(response);

            var previsaoJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<PrevisaoAtualDto>(previsaoJson);
        }


        public async Task<PrevisaoEstendidaDto> ObterPrevisaoEstendida(string cidade)
        {
            var client = _httpClientFactory.CreateClient("client");
            var response = await client.GetAsync(BASE_ADDRESS + $"/forecast.json?q={cidade}&days={DIAS_PREVISAO}&key={KEY}");

            verificarStatusCodeResponse(response);

            var previsaoJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<PrevisaoEstendidaDto>(previsaoJson);
        }

        private void verificarStatusCodeResponse(HttpResponseMessage? response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                throw new AcessoNegadoWeatherApiException("Acesso negado, verifique a sua chave(token) de Consumo da API Externa WeatherAPI!");

            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new CidadeNaoLocalizadaException("Cidade não localizada, verifique a sua busca!");

            if (response == null)
                throw new SemRespostaDaWeatherApiException("Não obtivemos resposta da WeatherAPI, tente novamente mais tarde!");
        }
    }
}