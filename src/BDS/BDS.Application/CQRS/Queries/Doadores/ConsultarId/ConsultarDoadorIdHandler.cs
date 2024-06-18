using BDS.Core.Repositories;
using DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Application.CQRS.Queries.Doadores.ConsultarId
{
    public class ConsultarDoadorIdHandler : IRequestHandler<ConsultarDoadorId, DoadorViewModel>
    {

        private readonly IDoadorRepository _repository;


        public ConsultarDoadorIdHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }


        public async Task<DoadorViewModel> Handle(ConsultarDoadorId request, CancellationToken cancellationToken)
        {
            var doador = await _repository.ConsultarIdAsync(request.Id);


            if (doador is null) return default;

            var doadorViwModel = new DoadorViewModel(doador.Nome
                                                    , doador.Email
                                                    , doador.DataNascimento
                                                    , doador.Genero
                                                    , doador.Peso
                                                    , doador.TipoSanquineo
                                                    , doador.Fator
                                                    , doador.Doacao
                                                    , doador.Endereco
                                                    , doador.Ativo);

            return doadorViwModel;
        }
    }
}
