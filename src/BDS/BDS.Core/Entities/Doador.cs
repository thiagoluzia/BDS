using BDS.Core.Enums;
using BDS.Core.ValueObjects;

namespace BDS.Core.Entities
{
    public class Doador :  BaseEntity
    {


        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public double Peso { get; private set; }
        public TipoSanquineo TipoSanquineo { get; private set; }
        public FatorRh Fator { get; private set; }
        public ICollection<Doacao?> Doacoes { get; private set; }
        public Endereco Endereco { get; private set; }

        protected Doador(){}

        public Doador(string nome, string email, DateTime dataNascimento, Genero genero, double peso, TipoSanquineo tipoSanquineo, FatorRh fator, Endereco endereco)
        {

            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = ValidarPeso(peso);
            TipoSanquineo = tipoSanquineo;
            Fator = fator;
            Endereco = endereco;

            //Doacoes = new List<Doacao
        }

        public void Atualizar(string nome, string email, double peso, Endereco endereco, Genero genero)
        {

            Email = email; 
            Nome = nome;
            Peso = peso;
            Endereco = endereco;
            Genero = genero;
        }

        public void ValidarEmailUnico(bool existeEmail)
        {
            if(existeEmail)
                throw new Exception("O e-mail já se encontra cadastrado");
        }

        public double  ValidarPeso(double peso)
        {
            if (peso <= (double)Enums.Peso.PESO_MINIMO)
                throw new Exception("Abaixo do peso permitido para cadastro de doador.");

            return peso;
        }
    }
}
