using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Tests
{
    public class PrevisaoAtualTests
    {
        [Fact]
        public void Teste_CriacaoInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoAtual = new PrevisaoAtual(25, 80, "Chuva", 20, Guid.NewGuid());

            Assert.NotNull(previsaoAtual);
        }

        [Fact]
        public void Teste_PropriedadeTemperaturaDaInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoAtual = new PrevisaoAtual(25, 80, "Chuva", 20, Guid.NewGuid());

            Assert.Equal(25, previsaoAtual.Temperatura);
        }

        [Fact]
        public void Teste_PropriedadeUmidadeDaInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoAtual = new PrevisaoAtual(25, 80, "Chuva", 20, Guid.NewGuid());

            Assert.Equal(80, previsaoAtual.Umidade);
        }

        [Fact]
        public void Teste_PropriedadeDescricaoDaInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoAtual = new PrevisaoAtual(25, 80, "Chuva", 20, Guid.NewGuid());

            Assert.Equal("Chuva", previsaoAtual.DescricaoTempo);
        }

        [Fact]
        public void Teste_PropriedadeVelocidadeVentoDaInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoAtual = new PrevisaoAtual(25, 80, "Chuva", 20, Guid.NewGuid());

            Assert.Equal(20, previsaoAtual.VelocidadeVento);
        }
    }
}
