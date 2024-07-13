using BDS.Core.Entities;
using BDS.Core.Enums;
using BDS.Core.Repositories;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doacoes.Incluir
{
    public class IncluirDoacaoHandler : IRequestHandler<IncluirDoacao, Guid>
    {

        private readonly IDoacaoRepository  _doacaoRepository;
        private readonly IDoadorRepository  _doadorRepository;
        private readonly IEstoqueRepository _estoqueRepository;


        public IncluirDoacaoHandler(IDoacaoRepository doacaoRepository, IDoadorRepository doadorRepository, IEstoqueRepository estoqueRepository)
        {
            _doacaoRepository  = doacaoRepository;
            _doadorRepository  = doadorRepository;
            _estoqueRepository = estoqueRepository;
        }


        public async Task<Guid> Handle(IncluirDoacao request, CancellationToken cancellationToken)
        {
            var doacaoElegivel = await Elegivel(request.DoadorID, request);

            if (!doacaoElegivel)
                return Guid.Empty;


            var doacao = new Doacao(request.DoadorID, request.DataDoacao, request.QuantidadeML);

            await _doacaoRepository.IncluirAsync(doacao);

            if(doacao.Id == Guid.Empty)
                return Guid.Empty;

            AtualizarEstoque(request.DoadorID, request.QuantidadeML);


            return doacao.Id;
        }
      
        public async Task<bool> Elegivel(Guid idDoador, IncluirDoacao doacao)
        {

            var doadorElegivel = await _doadorRepository.ConsultarIdAsync(idDoador);

            var doacaoElegivel = new Doacao(idDoador, doacao.DataDoacao, doacao.QuantidadeML);

            if (doadorElegivel.Elegibilidade(doadorElegivel.Peso) && doacaoElegivel.Elegibilidade())
                return true;

            return false;

        }

        private async void AtualizarEstoque(Guid id,  int quantidadeML)
        {
            var tipoSanguineo = await TipoSanqguineoDoador(id);

            var estoque = new BDS.Core.Entities.Estoque(  tipoSanguineo.TipoSanquineo
                                                        , tipoSanguineo.Fator
                                                        , quantidadeML);

            await _estoqueRepository.AtualizarEstoque(estoque);

        }

        private async Task<Doador> TipoSanqguineoDoador(Guid id)
        {
            var doador = await _doadorRepository.ConsultarIdAsync(id);

            if (doador is null)
                return null;

            return  doador;
        }

    }
}
