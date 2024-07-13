using BDS.Core.Entities;
using BDS.Core.Repositories;
using BDS.Infrastructure.Integrations.Sendgrid.Model;
using BDS.Infrastructure.Integrations.Sendgrid.Services;
using Hangfire;
using Microsoft.Extensions.Hosting;

namespace BDS.Application.Abstractions.Workers
{
    public class NotificaBaixaEstoqueWorker : BackgroundService, INotificaBaixaEstoqueWorker
    {
        private readonly IEstoqueRepository _repository;
        private readonly ISendgridService _sendgridService;


        public NotificaBaixaEstoqueWorker(IEstoqueRepository repository, ISendgridService sendgridService)
        {
            _repository = repository;
            _sendgridService = sendgridService;
        }


        public async Task NotificaBaixaEstoque()
        {

            var estoqueBaixo = await _repository.ConsultarEstoque();

            foreach (var estoque in estoqueBaixo)
            {
                if (estoque.QuantidadeML <= 420)
                {
                    EnviarEmail(estoque);
                    Console.WriteLine($"Job Delayed: {DateTime.Now}");
                }
            }

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            #region Sem Hangfire
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    NotificaBaixaEstoque();

            //    await Task.Delay(TimeSpan.FromHours(24.0), stoppingToken);
            //}
            #endregion

            #region Com Hangfire

            RecurringJob.AddOrUpdate("Notificar estoque minimo.", () => NotificaBaixaEstoque(), "0 6 * * *");

            #endregion

        }

        protected void EnviarEmail(Estoque estoque)
        {
            _sendgridService.Enviar(new EmailRequest
            {
                Assunto = $"Estoque Baixo - Sangue {estoque.TipoSanquineo}, {estoque.FatorRh}" ,
                Destinatario = "contabilidade.mouraluzia@gmail.com",
                Corpo = MontarCorpoEmail(estoque)
            });
        }

        public string MontarCorpoEmail(Estoque estoque)
        {
            var corpo = $@"<!DOCTYPE html>
                  <html lang=""pt-BR"">
                  <head>
                      <meta charset=""UTF-8"">
                      <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                      <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"">
                      <style>
                          body {{
                              font-family: Arial, sans-serif;
                              background-color: #f6f6f6;
                              margin: 0;
                              padding: 0;
                          }}
                          .container {{
                              max-width: 600px;
                              margin: 20px auto;
                              background-color: #ffffff;
                              padding: 20px;
                              border-radius: 8px;
                              box-shadow: 0 2px 4px rgba(0,0,0,0.1);
                          }}
                          .header {{
                              text-align: center;
                              padding-bottom: 20px;
                          }}
                          .header i {{
                              font-size: 48px;
                              color: #ff9900;
                          }}
                          .content {{
                              font-size: 16px;
                              line-height: 1.6;
                              color: #333333;
                          }}
                          .content a {{
                              color: #1a73e8;
                              text-decoration: none;
                          }}
                          .content a:hover {{
                              text-decoration: underline;
                          }}
                          .table-container {{
                              margin-top: 20px;
                          }}
                          table {{
                              width: 100%;
                              border-collapse: collapse;
                              margin-bottom: 20px;
                          }}
                          th, td {{
                              padding: 10px;
                              text-align: left;
                              border-bottom: 1px solid #dddddd;
                          }}
                          th {{
                              background-color: #f2f2f2;
                              font-weight: bold;
                          }}
                          tr:nth-child(even) {{
                              background-color: #f9f9f9;
                          }}
                          tr:hover {{
                              background-color: #f1f1f1;
                          }}
                          .footer {{
                              text-align: center;
                              font-size: 14px;
                              color: #777777;
                          }}
                      </style>
                  </head>
                  <body>
                      <div class=""container"">
                          <div class=""header"">
                              <i class=""fas fa-hospital""></i>
                          </div>
                          <div class=""content"">
                              <p>Atenção!</p>
                              <p>Estoque baixo para o seguinte tipo sanguíneo:</p>
                              <div class=""table-container"">
                                  <table>
                                      <thead>
                                          <tr>
                                              <th>Tipo</th>
                                              <th>Fator</th>
                                              <th>Quantidade</th>
                                          </tr>
                                      </thead>
                                      <tbody>
                                          <tr>
                                              <td>{estoque.TipoSanquineo}</td>
                                              <td>{estoque.FatorRh}</td>
                                              <td>{estoque.QuantidadeML}</td>
                                          </tr>
                                      </tbody>
                                  </table>
                              </div>
                              <p>Se tiver dúvidas, entre em contato com o <a href=""#"">serviço responsável do setor</a>.</p>
                          </div>
                          <div class=""footer"">
                              <p>Atenciosamente,<br>BDS</p>
                          </div>
                      </div>
                  </body>
                  </html>";

            return corpo;
        }

    }
}
