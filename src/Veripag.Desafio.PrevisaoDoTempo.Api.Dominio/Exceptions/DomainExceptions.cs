namespace Veripag.Desafio.PrevisaoDoTempo.Api.Dominio.Exceptions
{
    public class DomainExceptions : Exception
    {
        public DomainExceptions(string? message) : base(message)
        {

        }

        public static void Lancar(Func<bool> expressao, String mensagem)
        {
            if (expressao.Invoke() == true)
            {
                throw new DomainExceptions(mensagem);
            }
        }
    }
}
