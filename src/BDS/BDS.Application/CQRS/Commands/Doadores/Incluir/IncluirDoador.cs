using BDS.Core.Entities;
using BDS.Core.Enums;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doadores.Incluir
{
    public class IncluirDoador : IRequest<Guid>
    {

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public TipoSanquineo TipoSanquineo { get; private set; }
        public FatorRh Fator { get; private set; }
        public List<Doacao> Doacoes { get; private set; }
        public Endereco Endereco { get; private set; }
        public Guid EnderecoId { get; set; }


        public IncluirDoador(string nome, string email, DateTime dataNascimento, Genero genero, double peso, TipoSanquineo tipoSanquineo, FatorRh fator,  Guid enderecoId)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanquineo = tipoSanquineo;
            Fator = fator;
            Doacoes = new List<Doacao>();
            EnderecoId = enderecoId;
        }

    }
}
