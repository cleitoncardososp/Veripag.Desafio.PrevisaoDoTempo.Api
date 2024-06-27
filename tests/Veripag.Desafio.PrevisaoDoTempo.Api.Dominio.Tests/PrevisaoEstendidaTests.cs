using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Tests
{
    public class PrevisaoEstendidaTests
    {
        [Fact]
        public void Teste_CriacaoInstanciaPrevisaoEstendida_Sucesso()
        {
            var previsaoEstendida = new PrevisaoEstendida("2024-06-20", 30, 75, "Ensolarado", 10, Guid.NewGuid());

            Assert.NotNull(previsaoEstendida);
        }

        [Fact]
        public void Teste_PropriedadeDiaDaInstanciaPrevisaoEstendida_Sucesso()
        {
            var previsaoEstendida = new PrevisaoEstendida("2024-06-20", 30, 75, "Ensolarado", 10, Guid.NewGuid());

            Assert.Equal("2024-06-20", previsaoEstendida.Dia);
        }

        [Fact]
        public void Teste_PropriedadeTemperaturaDaInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoEstendida = new PrevisaoEstendida("2024-06-20", 30, 75, "Ensolarado", 10, Guid.NewGuid());

            Assert.Equal(30, previsaoEstendida.Temperatura);
        }

        [Fact]
        public void Teste_PropriedadeUmidadeDaInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoEstendida = new PrevisaoEstendida("2024-06-20", 30, 75, "Ensolarado", 10, Guid.NewGuid());

            Assert.Equal(75, previsaoEstendida.Umidade);
        }

        [Fact]
        public void Teste_PropriedadeDescricaoDaInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoEstendida = new PrevisaoEstendida("2024-06-20", 30, 75, "Ensolarado", 10, Guid.NewGuid());

            Assert.Equal("Ensolarado", previsaoEstendida.DescricaoTempo);
        }

        [Fact]
        public void Teste_PropriedadeVelocidadeVentoDaInstanciaPrevisaoAtual_Sucesso()
        {
            var previsaoEstendida = new PrevisaoEstendida("2024-06-20", 30, 75, "Ensolarado", 10, Guid.NewGuid());

            Assert.Equal(10, previsaoEstendida.VelocidadeVento);
        }

    }
}
