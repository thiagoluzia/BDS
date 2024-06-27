namespace BDS.Core.Entities
{
    //TODO: Implementa API para consultar ViaCEP
    //TODO: Implementar Cache para consultas da ViaCEP
    public class Endereco : BaseEntity
    {

        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }
        public Guid DoadorID { get; private set; }
        public Doador Doador { get; private set; }


        protected Endereco() { }


        public Endereco(string logradouro, string cidade, string bairro, string uF, string cEP, Guid doadorID)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Bairro = bairro;
            UF = uF;
            CEP = cEP;
            DoadorID = doadorID;
        }
    }
}
