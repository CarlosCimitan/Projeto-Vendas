using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace ProjetoVendas.Services.Email
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task<bool> EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            try
            {
                using (var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
                {
                    client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    client.EnableSsl = _smtpSettings.EnableSSL;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_smtpSettings.Username),
                        Subject = assunto,
                        Body = mensagem,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(destinatario);

                    await client.SendMailAsync(mailMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                {
                }
            }
        }
    }
}
