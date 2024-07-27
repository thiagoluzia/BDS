using BDS.Infrastructure.Integrations.ViaCep.Models;
using System.Text.Json;

namespace BDS.Infrastructure.Integrations.ViaCep.Services
{
    public class ApiViaCepService : IApiViaCepService
    {

        private readonly HttpClient _httpClient;


        public ApiViaCepService(HttpClient httpClient)  
        {
            _httpClient = httpClient;
        }


        public async Task<Endereco> ConsultarCepAsync(string cep)
        {
            var request = @$"https://viacep.com.br/ws/{cep}/json";
            var response = await _httpClient.GetAsync(request);

            if(response.IsSuccessStatusCode)
            {
                var contentStream = await response.Content.ReadAsStreamAsync();
                var endereco = await JsonSerializer.DeserializeAsync<Endereco>(contentStream);

                return endereco;
            }
            else 
                return null;
            

        }
    }
}
