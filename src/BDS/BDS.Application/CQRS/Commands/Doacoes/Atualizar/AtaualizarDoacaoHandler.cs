﻿using BDS.Core.Entities;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Atualizar
{
    public class AtaualizarDoacaoHandler : IRequestHandler<AtualizarDoacao, Unit>
    {
        private readonly IDoacaoRepository _repository;


        public AtaualizarDoacaoHandler(IDoacaoRepository repository)
        {
            _repository = repository;
        }

        //TODO: Corrigir 
        public async Task<Unit> Handle(AtualizarDoacao request, CancellationToken cancellationToken)
        {
            var doacao = _repository.ConsultarIdAsync(request.Id);

            doacao.AtualizarDoacao(request.QuantidadeML);

            await _repository.AlterarAsync(doacao);

            return Unit.Value;
        }
    }
}