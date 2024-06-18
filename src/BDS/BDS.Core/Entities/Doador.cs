using BDS.Core.Enums;
using BDS.Core.Services.Interfaces;
using BDS.Core.ValueObjects;

namespace BDS.Core.Entities
{
    public class Doador :  BaseEntity
    {

        private readonly IDoadorService _service;

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public TipoSanquineo TipoSanquineo { get; private set; }
        public FatorRh Fator { get; private set; }
        public List<Doacao> Doacao { get; private set; }
        public Endereco Endereco { get; private set; }
        public bool Ativo { get; private set; }


        public Doador(string nome, string email, DateTime dataNascimento, Genero genero, double peso, TipoSanquineo tipoSanquineo, FatorRh fator, Endereco endereco, IDoadorService service)
        {
            _service = service;

            

            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanquineo = tipoSanquineo;
            Fator = fator;
            Doacao = new List<Doacao>();
            Endereco = endereco;

            Doacao = new List<Doacao>();
            Ativo = true;

        }

        public void Atualizar(string nome, string email, double peso, Endereco endereco, Genero genero)
        {
            if (!ExisteEmail(email))
                Email = email;
            else
                return;

            Nome = nome;
            Peso = peso;
            Endereco = endereco;
            Genero = genero;
        }

        private bool ExisteEmail(string email)
        {

            if (_service.ExisteEmail(email))
            {
                throw new ArgumentException("Email já existe");
            }

            return false;

        }

    }
}
