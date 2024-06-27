
using Microsoft.Data.SqlClient;
using Veripag.Desafio.PrevisaoDoTempo.Api.Aplicacao.Interfaces.IHistoricoDeBuscasRepository;
using Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions;

namespace Veripag.Desafio.PrevisaoDoTempo.Api.Servico.Services.ExcluirHistoricoDeBuscaService
{
    public class ExcluirHistoricoDeBuscaService : IHostedService
    {
        private Timer? _timer;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ExcluirHistoricoDeBuscaService> _logger;
        const int TEMPO_LIMPEZA_CACHE = 3600;

        public ExcluirHistoricoDeBuscaService(IServiceScopeFactory scopeFactory, Timer? timer = null, ILogger<ExcluirHistoricoDeBuscaService> logger = null)
        {
            _scopeFactory = scopeFactory;
            _timer = timer;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(async x => await ExecutarJob(), null, TimeSpan.Zero, TimeSpan.FromSeconds(TEMPO_LIMPEZA_CACHE));
            return Task.CompletedTask;
        }

        private async Task ExecutarJob()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                try
                {
                    var _historicoDeBuscasRepository = scope.ServiceProvider.GetRequiredService<IHistoricoDeBuscasRepository>();
                    await _historicoDeBuscasRepository.ExcluirHistoricoDeBuscas();
                    _logger.LogInformation($"LIMPEZA DO CACHE CONCLUIDA EM {DateTime.Now}");
                }
                catch (InvalidOperationException ex)
                {
                    _logger.LogError($"FALHA AO CONECTAR AO BANCO DE DADOS, VERIFIQUE SE O SERVIDOR/BANCO ESTÃO DISPONÍVEIS E O NOME DE USUÁRIO/SENHA ESTÃO CORRETOS");
                    _logger.LogError($"FALHA AO EXECUTAR A LIMPEZA DO CACHE EM {DateTime.Now}");
                    await Task.CompletedTask;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
