using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities.Enums;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Tests
{
    public class HistoricoBuscaTests
    {
        [Fact]
        public void Teste_CriacaoDeInstancia_HistoricoBusca_Sucesso()
        {
            var historicoBusca = new HistoricoBusca("Diadema", TipoPrevisao.ATUAL);

            Assert.NotNull(historicoBusca);
        }

        [Fact]
        public void Teste_CriacaoDeInstancia_HistoricoBusca_Falha()
        {
            Assert.Throws<DomainExceptions>(() => new HistoricoBusca(null, TipoPrevisao.ESTENDIDA));
        }

        [Fact]
        public void Teste_CidadePesquisada_HisoticoBusca_Sucesso()
        {
            var historicoBusca = new HistoricoBusca("Diadema", TipoPrevisao.ATUAL);

            Assert.Equal("Diadema", historicoBusca.CidadePesquisada);
        }

        [Fact]
        public void Teste_DataBuscaEhHoje_HistoricoBusca_Sucesso()
        {
            var historicoBusca = new HistoricoBusca("Diadema", TipoPrevisao.ESTENDIDA);

            Assert.Equal(DateTime.Today.Date, historicoBusca.DataBusca.Date);
        }

        [Fact]
        public void Teste_TipoPrevisao_Atual_HistoricoBusca_Sucesso()
        {
            var historicoBusca = new HistoricoBusca("Diadema", TipoPrevisao.ATUAL);

            Assert.Equal(TipoPrevisao.ATUAL, historicoBusca.TipoPrevisao);
        }

        [Fact]
        public void Teste_TipoPrevisao_Atual_HistoricoBusca_Falha()
        {
            var historicoBusca = new HistoricoBusca("Diadema", TipoPrevisao.ESTENDIDA);

            Assert.NotEqual(TipoPrevisao.ATUAL, historicoBusca.TipoPrevisao);
        }

        [Fact]
        public void Teste_TipoPrevisao_Estendida_HistoricoBusca_Sucesso()
        {
            var historicoBusca = new HistoricoBusca("Diadema", TipoPrevisao.ESTENDIDA);

            Assert.Equal(TipoPrevisao.ESTENDIDA, historicoBusca.TipoPrevisao);
        }

        [Fact]
        public void Teste_TipoPrevisao_Estendida_HistoricoBusca_Falha()
        {
            var historicoBusca = new HistoricoBusca("Diadema", TipoPrevisao.ATUAL);

            Assert.NotEqual(TipoPrevisao.ESTENDIDA, historicoBusca.TipoPrevisao);
        }
    }
}
