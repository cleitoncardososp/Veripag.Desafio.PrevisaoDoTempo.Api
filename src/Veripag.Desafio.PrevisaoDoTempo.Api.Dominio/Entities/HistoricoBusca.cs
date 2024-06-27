using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.Enums;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities
{
    public class HistoricoBusca
    {
        public Guid Id { get; set; }
        public DateTime DataBusca { get; set; }
        public string CidadePesquisada { get; set; }
        public TipoPrevisao TipoPrevisao { get; set; }

        public HistoricoBusca(string cidadePesquisada, TipoPrevisao tipoPrevisao)
        {
            DomainExceptions.Lancar(() => cidadePesquisada == null, "Cidade pesquisada é inválida");

            Id = Guid.NewGuid();
            DataBusca = DateTime.Now;
            CidadePesquisada = cidadePesquisada;
            TipoPrevisao = tipoPrevisao;
        }
    }
}
