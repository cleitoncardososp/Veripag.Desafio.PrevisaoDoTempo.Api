namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Entities
{
    public class PrevisaoAtual
    {
        public Guid Id { get; set; }
        public double Temperatura { get; set; }
        public double Umidade { get; set; }
        public string DescricaoTempo { get; set; }
        public double VelocidadeVento { get; set; }

        public Guid HistoricoBuscaId { get; set; }
        public HistoricoBusca HistoricoBusca { get; set; }

        public PrevisaoAtual(double temperatura, double umidade, string descricaoTempo, double velocidadeVento, Guid historicoBuscaId)
        {
            Id = Guid.NewGuid();
            Temperatura = temperatura;
            Umidade = umidade;
            DescricaoTempo = descricaoTempo;
            VelocidadeVento = velocidadeVento;
            HistoricoBuscaId = historicoBuscaId;
        }
    }
}
