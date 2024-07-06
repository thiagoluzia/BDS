using System.Text.Json.Serialization;

namespace BDS.Infrastructure.Integrations.ViaCep.Models
{
    public  class Endereco
    {

        [JsonPropertyName("cep")]
        public string? Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }

        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }
        [JsonPropertyName("localidade")]
        public string? Cidade { get; set; }

        [JsonPropertyName("uf")]
        public string? Uf { get; set; }


    }
}
