using MediatR;
using Microsoft.AspNetCore.Mvc;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Historico.ObterHistoricoDeBusca;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Previsao.ObterPrevisaoAtualPorCidade;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Previsao.ObterPrevisaoEstendidaPorCidade;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Controllers
{
    [ApiController]
    [Route("v1/previsao")]
    public class PrevisaoController : ControllerBase
    {
        public IMediator Mediator;
        private ILogger<PrevisaoController> _logger;

        public PrevisaoController(IMediator mediator, ILogger<PrevisaoController> logger = null)
        {
            Mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Rota que recebe o nome da cidade como parâmetro na query e retorna a previsão do tempo atual
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        [HttpGet("obter-previsao-atual")]
        public async Task<ActionResult> ObterPrevisaoAtual([FromQuery] string cidade)
        {
            try
            {
                ObterPrevisaoAtualPorCidadeResponse response = await
                    Mediator.Send(new ObterPrevisaoAtualPorCidadeQuery(cidade));

                return Ok(response);
            }
            catch (AcessoNegadoWeatherApiException ex)
            {
                _logger.LogError(ex.Message);
                return Forbid(ex.Message);
            }
            catch (CidadeNaoLocalizadaException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (SemRespostaDaWeatherApiException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("FALHA NA CONEXÃO COM O BANCO DE DADOS!");
                return StatusCode(StatusCodes.Status502BadGateway, 
                    "Falha na conexão com o Banco de Dados!");
            }
            catch (Exception ex){
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Ocorreu um erro inesperado, tente novamente mais tarde");
            }
        }

        /// <summary>
        /// Rota que recebe o nome da cidade como parâmetro na query e retorna a previsão estendida
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        [HttpGet("obter-previsao-estendida")]
        public async Task<ActionResult> ObterPrevisaoEstendida([FromQuery] string cidade)
        {
            try
            {
                List<ObterPrevisaoEstendidaPorCidadeResponse> response = await 
                    Mediator.Send(new ObterPrevisaoEstendidaPorCidadeQuery(cidade));

                return Ok(response);
            }
            catch (AcessoNegadoWeatherApiException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (CidadeNaoLocalizadaException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (SemRespostaDaWeatherApiException ex)
            {
                _logger.LogError(ex.Message);
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("FALHA NA CONEXÃO COM O BANCO DE DADOS!");
                return StatusCode(StatusCodes.Status502BadGateway,
                    "Falha na conexão com o Banco de Dados!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro inesperado, tente novamente mais tarde");
            }
        }

        /// <summary>
        /// Rota sem necessidade de parâmetros de entrada e que retorna uma lista do histórico de busca
        /// </summary>
        /// <returns></returns>
        [HttpGet("obter-hitorico-buscas")]
        public async Task<ActionResult> ObterHistoricoBuscas()
        {
            try
            {
                List<ObterHistoricoDeBuscaResponse> response = await
                    Mediator.Send(new ObterHistoricoDeBuscaQuery());

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError("FALHA NA CONEXÃO COM O BANCO DE DADOS!");
                return StatusCode(StatusCodes.Status502BadGateway,
                    "Falha na conexão com o Banco de Dados!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro inesperado, tente novamente mais tarde");
            }
        }
    }
}