using MediatR;

namespace BDS.Application.CQRS.Queries.Doadores.ConsultarEmail
{
    public class ConsultarEmailDoador : IRequest<bool>
    {

        public string Email { get; private set; }


        public ConsultarEmailDoador(string email)
        {
            Email = email;
        }
    }
}
