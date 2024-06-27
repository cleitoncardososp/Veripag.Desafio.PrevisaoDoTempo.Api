using MediatR;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Previsao.ObterPrevisaoEstendidaPorCidade
{
    public class ObterPrevisaoEstendidaPorCidadeQuery : IRequest<List<ObterPrevisaoEstendidaPorCidadeResponse>>
    {
        public string Cidade { get; set; }

        public ObterPrevisaoEstendidaPorCidadeQuery(string cidade)
        {
            Cidade = cidade;
        }
    }
}
