namespace BDS.Application.DTOs
{
    public class EnderecoViewModel
    {
        public string? Cep { get; private set; }
        public string? Logradouro { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Uf { get; private set; }
        public string? Numero { get; private set; }
        public string? Referencia { get; private set; }


        public EnderecoViewModel(string? cep, string? logradouro, string? bairro, string? cidade, string? uf, string? numero, string? referencia)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Numero = numero;
            Referencia = referencia;
        }
    }
}
