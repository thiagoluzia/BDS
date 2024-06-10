using BDS.Core.Entities.Enums;

namespace BDS.Core.Entities
{
    public class Doador : BaseEntity
    {
        public Doador(string nome,
            string email, 
            DateTime dataNascimento,
            Genero genero,
            double peso,
            TipoSanquineo tipoSanquineo,
            FatorRh fator,
            Endereco endereco)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanquineo = tipoSanquineo;
            Fator = fator;
            Endereco = endereco;

            Doacao = new List<Doacao>();
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public TipoSanquineo TipoSanquineo { get; private set; }
        public FatorRh Fator { get; private set; }
        public List<Doacao> Doacao { get; private set; }
        public Endereco Endereco { get; private set; }


        public void AtualizarDoador(string nome,
            string email, 
            DateTime dataNascimento,
            double peso,
            Endereco endereco)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Peso = peso;
            Endereco = endereco;
        }
    }
}
