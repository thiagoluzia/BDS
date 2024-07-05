using BDS.Application.DTOs;

namespace BDS.Application.Abstractions.External.ViaCEP
{
    public interface IViaCepService
    {
        Task<EnderecoViewModel> ConsultarCepAsync(string cep);
    }
}
