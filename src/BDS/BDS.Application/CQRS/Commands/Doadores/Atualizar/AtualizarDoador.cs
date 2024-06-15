using BDS.Core.Entities;
using BDS.Core.Enums;
using MediatR;

namespace BDS.Application.CQRS.Commands.Doadores.Atualizar
{
    public class AtualizarDoador : IRequest<Unit>
    {

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public List<Doacao> Doacao { get; private set; }
        public Endereco Endereco { get; private set; }


        public AtualizarDoador(Guid id, string nome, string email, Genero genero, double peso, List<Doacao> doacao, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Genero = genero;
            Peso = peso;
            Endereco = endereco;
        }
    }
}
