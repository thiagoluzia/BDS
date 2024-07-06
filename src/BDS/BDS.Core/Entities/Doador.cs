using BDS.Core.Enums;
using BDS.Core.Services.Interfaces;
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
            TipoSanquineo = tipoSanquineo;
            Fator = fator;
            Endereco = endereco;

            //Doacoes = new List<Doacao

            if (PesoPermitido())
                Peso = peso;
            else
                throw new Exception("Abaixo do peso permitido para cadastro de doador.");
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


        public bool Elegibilidade()
        {
            if(MaiorIdade() && PesoPermitido() && IntervaloDoacaoPermitido())
                return true;

            return false;
        }
        protected bool MaiorIdade()
        {
            var hoje = DateTime.Today;

            // Calcula a idade considerando os dias exatos
            var idade = hoje.Year - DataNascimento.Year;

            // Ajusta a idade se o aniversário não ocorreu ainda neste ano
            if (hoje < DataNascimento.AddYears(idade))
                idade--;

            return idade >= (int)ELegibilidade.MAIOR_IDADE;
        }
        protected bool PesoPermitido()
        {
            if(Genero == Genero.Feminino  && Peso >= (int)ELegibilidade.PESO_MINIMO_FEMININO || Genero == Genero.Masculino && Peso >= (int)ELegibilidade.PESO_MINIMO_MASCULINO)
                return true;

            return false;
        }

        protected bool IntervaloDoacaoPermitido()
        {
            var dataDoacao = Doacoes.Max(d => d.DataDoacao);
            var hoje = DateTime.Today;
            var ultimaDoacao = (hoje - dataDoacao).Days;

            if (Genero == (Genero.Feminino) && ultimaDoacao >= (int)ELegibilidade.DIAS_DOACAO_FEMININO)
                return true;

            if (Genero == (Genero.Masculino) && ultimaDoacao >= (int)ELegibilidade.DIAS_DOACAO_MASCULINO)
                return true;

            return false;

        }

    }
}
