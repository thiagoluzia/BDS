using BDS.Infrastructure.Integrations.Sendgrid.Model;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BDS.Infrastructure.Integrations.Sendgrid.Services
{
    public class SendgridService : ISendgridService
    {

        private readonly string _usuarioSmtp = "thiago.mouraluzia@gmail.com";
        private readonly ISendGridClient _sendGridClient;


        public SendgridService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }


        public async Task Enviar(EmailRequest emailRequest)
        {

            //Envolvidos
            var from = new EmailAddress(_usuarioSmtp, "BDS Atendiemnto");
            var subject = emailRequest.Assunto;
            var to = new EmailAddress(emailRequest.Destinatario);

            //Conteúdo
            var htmlContent = "<strong>" + emailRequest.Corpo + "</strong>";

            //envio
            var msg = MailHelper.CreateSingleEmail(from, to, subject, emailRequest.Corpo, htmlContent);
            
            
            var response = await _sendGridClient.SendEmailAsync(msg);

   
        }

  
    }
}
