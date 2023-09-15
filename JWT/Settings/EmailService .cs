using MailKit;
using MailKit.Net.Smtp;
using MimeKit;


namespace JWT.Settings
{
    public class EmailService
    {

        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMailAsync(MimeMessage message)
        {
            using var emailMessage = new MimeMessage();
            string username = _configuration["EmailSettings:Username"];
            string password = _configuration["EmailSettings:Password"];


            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync("smtp.yandex.ru", 25, false);
                    await smtpClient.AuthenticateAsync(username, password);
                await smtpClient.SendAsync(emailMessage);

                await smtpClient.DisconnectAsync(true);
            }

        }

    }
}
