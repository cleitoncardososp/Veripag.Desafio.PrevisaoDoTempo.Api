namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Previsao.ObterPrevisaoAtualPorCidade
{
    public class ObterPrevisaoAtualPorCidadeResponse
    {
        public double Temperatura { get; set; }
        public double Umidade { get; set; }
        public string DescricaoTempo { get; set; }
        public double VelocidadeVento { get; set; }
    }
}
