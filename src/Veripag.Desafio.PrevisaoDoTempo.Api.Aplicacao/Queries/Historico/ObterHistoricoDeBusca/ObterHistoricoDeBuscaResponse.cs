using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.Enums;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Historico.ObterHistoricoDeBusca
{
    public class ObterHistoricoDeBuscaResponse
    {
        public DateTime DataBusca { get; set; }
        public string CidadePesquisada { get; set; }
        public TipoPrevisao TipoPrevisao { get; set; }
    }
}
