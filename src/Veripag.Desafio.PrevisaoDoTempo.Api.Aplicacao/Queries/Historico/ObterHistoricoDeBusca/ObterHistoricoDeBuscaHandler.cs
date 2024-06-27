using MediatR;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IHistoricoDeBuscasRepository;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Queries.Historico.ObterHistoricoDeBusca
{
    public class ObterHistoricoDeBuscaHandler : IRequestHandler<ObterHistoricoDeBuscaQuery, List<ObterHistoricoDeBuscaResponse>>
    {
        private readonly IHistoricoDeBuscasRepository _historicoDeBuscasRepository;

        public ObterHistoricoDeBuscaHandler(IHistoricoDeBuscasRepository context)
        {
            _historicoDeBuscasRepository = context;
        }

        public async Task<List<ObterHistoricoDeBuscaResponse>> Handle(ObterHistoricoDeBuscaQuery request, CancellationToken cancellationToken)
        {
            var listaHistoricoBanco = await _historicoDeBuscasRepository.ObterTodoHistorico();

            List<ObterHistoricoDeBuscaResponse> listaHistorico = new List<ObterHistoricoDeBuscaResponse>();

            foreach (var historico in listaHistoricoBanco)
            {
                listaHistorico.Add(
                    new ObterHistoricoDeBuscaResponse()
                    {
                        DataBusca = historico.DataBusca,
                        CidadePesquisada = historico.CidadePesquisada,
                        TipoPrevisao = historico.TipoPrevisao
                    }
                );
            }

            return listaHistorico; 
        }
    }
}
