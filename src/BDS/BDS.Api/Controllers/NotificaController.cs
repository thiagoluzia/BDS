//using Azure.Communication.Sms;
using Microsoft.AspNetCore.Mvc;
//using SendGrid;
//using SendGrid.Helpers.Mail;

namespace BDS.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NotificaController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> Email(string emailDe, string emailPara, string assunto, string texto ) 
        //{
        //    var apiKey = Environment.GetEnvironmentVariable("KEY_SENDGRID_30062024");
        //    var client = new SendGridClient("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");
        //    var from = new EmailAddress(emailDe, "Clinica");
        //    var subject = assunto;
        //    var to = new EmailAddress(emailPara, "Cliente");
        //    var plainTextContent = texto;
        //    var htmlContent = Template(texto);
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg);


        //    if (!response.IsSuccessStatusCode)
        //        return BadRequest();

        //    return Ok(response);


        //}


        //[HttpPost]
        //public IActionResult SMS(string de, string para)
        //{
        //    string connectionString = "endpoint=https://servicosms.unitedstates.communication.azure.com/;accesskey=EY6m4fDpi9DdGpmkPCEmydEhXJUPnRqh3anrU4GY5nOkzlKia4BCJQQJ99AFACULyCpvaoH8AAAAAZCSXMhj";
        //    SmsClient smsClient = new SmsClient(connectionString);
        //    var t = smsClient.Send(
        //        from: de,
        //        to: para,
        //        message: """Olá, Mundo 👋🏻 via SMS"""
        //    );

        //    return Ok(t);

        //}
        //public string Template(string body)
        //{
        //    var template = @$"<!DOCTYPE html>
        //                        <html lang=""pt-BR"">
        //                        <head>
        //                            <meta charset=""UTF-8"">
        //                            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        //                            <title>Template de Email para Clínica</title>
        //                            <style>
        //                                body {{
        //                                    font-family: Arial, sans-serif;
        //                                    margin: 0;
        //                                    padding: 0;
        //                                    background-color: #f4f4f4;
        //                                }}
        //                                .email-container {{
        //                                    max-width: 600px;
        //                                    margin: 0 auto;
        //                                    background-color: #fff;
        //                                    padding: 20px;
        //                                    border: 1px solid #ddd;
        //                                }}
        //                                .header {{
        //                                    background-color: #0073e6;
        //                                    color: white;
        //                                    padding: 10px;
        //                                    text-align: center;
        //                                }}
        //                                .header img {{
        //                                    max-width: 150px;
        //                                }}
        //                                .main-content {{
        //                                    padding: 20px;
        //                                }}
        //                                .main-content h1 {{
        //                                    color: #333;
        //                                }}
        //                                .main-content p {{
        //                                    color: #555;
        //                                    line-height: 1.6;
        //                                }}
        //                                .button {{
        //                                    display: inline-block;
        //                                    background-color: #0073e6;
        //                                    color: white;
        //                                    padding: 10px 20px;
        //                                    text-decoration: none;
        //                                    border-radius: 5px;
        //                                    margin-top: 10px;
        //                                }}
        //                                .footer {{
        //                                    text-align: center;
        //                                    color: #555;
        //                                    padding: 10px;
        //                                    border-top: 1px solid #ddd;
        //                                    margin-top: 20px;
        //                                }}
        //                                .footer a {{
        //                                    color: #0073e6;
        //                                    text-decoration: none;
        //                                }}
        //                            </style>
        //                        </head>
        //                        <body>
        //                            <div class=""email-container"">
        //                                <div class=""header"">
        //                                  <h2>Bem-vindo à Clínica XYZ</h2>
        //                                    <!--<img src=""#"" alt=""Logo da Clínica"">-->
        //                                </div>
        //                                <div class=""main-content"">
        //                                    <h1>Bem-vindo à Clínica XYZ</h1>
                                           
        //                                    <p>{body}</p>
                                            
        //                                    <a href=""https://www.clinica-xyz.com"" class=""button"">Conheça mais sobre a Clínica XYZ</a>
        //                                </div>
        //                                <div class=""footer"">
        //                                    <p>Ainda tem dúvidas? <a href=""mailto:contato@clinica-xyz.com"">Fale conosco</a></p>
        //                                    <p><a href=""#"">Treinamento</a> | <a href=""#"">Comunidade</a> | <a href=""#"">Suporte</a> | <a href=""#"">Entre em contato conosco</a></p>
        //                                </div>
        //                            </div>
        //                        </body>
        //                        </html>
        //                        ";

        //    return template;
        //}
    }
}
