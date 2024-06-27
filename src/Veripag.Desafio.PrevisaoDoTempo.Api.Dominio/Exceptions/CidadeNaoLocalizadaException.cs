namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions
{
    public class CidadeNaoLocalizadaException : Exception
    {
        public CidadeNaoLocalizadaException(string? message) : base(message)
        {
        }
    }
}
