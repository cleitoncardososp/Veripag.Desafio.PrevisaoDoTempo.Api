namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions
{
    public class FalhaNoAcessoAoBancoDeDadosException : Exception
    {
        public FalhaNoAcessoAoBancoDeDadosException(string? message) : base(message)
        {
        }
    }
}
