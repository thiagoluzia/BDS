using BDS.Core.Entities;
using BDS.Core.Enums;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Incluir
{
    public class IncluirDoacaoHandler : IRequestHandler<IncluirDoacao, Guid>
    {

        private readonly IDoacaoRepository _doacaoRepository;
        private readonly IDoadorRepository _doadorRepository;


        public IncluirDoacaoHandler(IDoacaoRepository doacaoRepository, IDoadorRepository doadorRepository)
        {
            _doacaoRepository = doacaoRepository;
            _doadorRepository = doadorRepository;
        }


        public async Task<Guid> Handle(IncluirDoacao request, CancellationToken cancellationToken)
        {
            var doacaoElegivel = await Elegivel(request.DoadorID, request);

            if (!doacaoElegivel)
                return Guid.Empty;


            var doacao = new Doacao(request.DoadorID, request.DataDoacao, request.QuantidadeML);

            await _doacaoRepository.IncluirAsync(doacao);

            return doacao.Id;
        }

      
        public async Task<bool> Elegivel(Guid idDoador, IncluirDoacao doacao)
        {

            var doadorElegivel = await _doadorRepository.ConsultarIdAsync(idDoador);

            var doacaoElegivel = new Doacao(idDoador, doacao.DataDoacao, doacao.QuantidadeML);

            if (doadorElegivel.Elegibilidade() && doacaoElegivel.Elegibilidade())
                return true;

            return false;

        }

    }
}
