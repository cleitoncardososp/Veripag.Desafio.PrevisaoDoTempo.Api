namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions
{
    public class AcessoNegadoWeatherApiException : Exception
    {
        public AcessoNegadoWeatherApiException(string? message) : base(message)
        {
        }
    }
}
