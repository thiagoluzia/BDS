using BDS.Core.Repositories;
using DTOs;
using MediatR;

namespace BDS.Application.CQRS.Queries.Doadores.Consultar
{
    public class ConsultarDoadorHandler : IRequestHandler<ConsultarDoador, IEnumerable<DoadorViewModel>>
    {

        private readonly IDoadorRepository _repository;


        public ConsultarDoadorHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<DoadorViewModel>> Handle(ConsultarDoador request, CancellationToken cancellationToken)
        {
            var doadores = await _repository.ConsultarAsync();

            var doadoresViewModel = doadores
                .Select(d => new DoadorViewModel(d.Nome
                                                 , d.Email
                                                 , d.DataInclusao
                                                 , d.Genero
                                                 , d.Peso
                                                 , d.TipoSanquineo
                                                 , d.Fator
                                                 , d.Doacoes
                                                 , d.Endereco
                                                 , d.Ativo))
                .ToList();

            return doadoresViewModel;

        }

    }
}
