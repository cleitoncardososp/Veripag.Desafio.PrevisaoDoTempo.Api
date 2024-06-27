using MediatR;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Previsao.ObterPrevisaoAtualPorCidade
{
    public class ObterPrevisaoAtualPorCidadeQuery : IRequest<ObterPrevisaoAtualPorCidadeResponse>
    {
        public string Cidade { get; set; }

        public ObterPrevisaoAtualPorCidadeQuery(string cidade)
        {
            Cidade = cidade;
        }
    }
}
