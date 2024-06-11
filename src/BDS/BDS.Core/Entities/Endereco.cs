namespace BDS.Core.Entities
{
    public class Endereco : BaseEntity
    {
        public string? Logradouro { get; set; }
        public string? Cidade { get; private set; }
        public string? Bairro { get; private set; }
        public string? UF { get; private  set; }
        public string? CEP { get; private set; }
        public Doador? DoadorId { get; private set; }
        public Doador? Doador { get; private set; }


        public Endereco(string? logradouro, string? cidade, string? bairro, string? uF, string? cEP, Doador? doadorId)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Bairro = bairro;
            UF = uF;
            CEP = cEP;
            DoadorId = doadorId;
        }


        public void AtualizarEndereco(string logradouro, string cidade, string bairro, string uF, string cEP, Doador doadorId)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Bairro = bairro;
            UF = uF;
            CEP = cEP;
            DoadorId = doadorId;
        }
    }
}
