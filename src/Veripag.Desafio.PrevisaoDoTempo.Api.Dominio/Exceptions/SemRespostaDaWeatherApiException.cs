namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions
{
    public class SemRespostaDaWeatherApiException : Exception
    {
        public SemRespostaDaWeatherApiException(string? message) : base(message)
        {
        }
    }
}
