using BDS.Infrastructure.Integrations.Sendgrid.Model;

namespace BDS.Infrastructure.Integrations.Sendgrid.Services
{
    public  interface ISendgridService
    {
        Task Enviar(EmailRequest request);
    }
}
