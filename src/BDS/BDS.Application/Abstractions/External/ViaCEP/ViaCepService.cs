using BDS.Application.DTOs;
using BDS.Infrastructure.Integrations.ViaCep.Services;


namespace BDS.Application.Abstractions.External.ViaCEP
{
    public class ViaCepService : IViaCepService
    {
        private readonly IApiViaCepService _service;


        public ViaCepService(IApiViaCepService service)
        {
            _service = service;
        }


        public async  Task<EnderecoViewModel> ConsultarCepAsync(string cep)
        {
            var endereco = await _service.ConsultarCepAsync(cep);

            if(endereco is not null) 
            {
                var enderecoViewModels = new EnderecoViewModel(endereco.Cep
                                                                , endereco.Logradouro
                                                                , endereco.Bairro
                                                                , endereco.Cidade
                                                                , endereco.Uf,"", "");
                
                return enderecoViewModels;
            }

            return null;
        }
    }
}
