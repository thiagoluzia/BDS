using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Queries.Doadores.ConsultarEmail
{
    public class ConsultarEmailHandler : IRequestHandler<ConsultarEmailDoador, bool>
    {
        private readonly IDoadorRepository _repository;


        public ConsultarEmailHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }


        public async Task<bool> Handle(ConsultarEmailDoador request, CancellationToken cancellationToken)
        {
            var emailExiste = await _repository.ConsultarEmail(request.Email);

            return emailExiste;
        }
    }
}
