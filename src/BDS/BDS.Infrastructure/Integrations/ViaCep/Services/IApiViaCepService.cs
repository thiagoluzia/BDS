using BDS.Infrastructure.Integrations.ViaCep.Models;

namespace BDS.Infrastructure.Integrations.ViaCep.Services
{
    public interface IApiViaCepService
    {
        Task<Endereco> ConsultarCepAsync(string cep);
    }
}
