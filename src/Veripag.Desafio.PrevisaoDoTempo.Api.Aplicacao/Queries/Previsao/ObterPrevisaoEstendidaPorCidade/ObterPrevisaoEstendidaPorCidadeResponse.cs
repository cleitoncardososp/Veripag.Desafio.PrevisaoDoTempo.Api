namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Previsao.ObterPrevisaoEstendidaPorCidade
{
    public class ObterPrevisaoEstendidaPorCidadeResponse
    {
        public string Data { get; set; }
        public double Temperatura { get; set; }
        public double Umidade { get; set; }
        public string DescricaoTempo { get; set; }
        public double VelocidadeVento { get; set; }
    }
}
