using BDS.Core.Enums;

namespace BDS.Core.Entities
{
    public class Doador :  BaseEntity
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
        public Guid EnderecoId { get; private set; }
        public bool Ativo { get; private set; }

        protected Doador(){}

        public Doador(string nome, string email, DateTime dataNascimento, Genero genero, double peso, TipoSanquineo tipoSanquineo, FatorRh fator, Guid enderecoId)
        {

            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanquineo = tipoSanquineo;
            Fator = fator;
            EnderecoId = enderecoId;

            Doacoes = new List<Doacao>();
            Ativo = true;

        }

        public void Atualizar(string nome, string email, double peso, Endereco endereco, Genero genero)
        {

            Email = email; 
            Nome = nome;
            Peso = peso;
            Endereco = endereco;
            Genero = genero;
        }

    }
}
