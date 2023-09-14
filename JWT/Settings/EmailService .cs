using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace JWT.Settings
{
    public class EmailService
    {
        public async Task SendMailAsync(string email, string sub, string message)
        {
            using var emailMessage = new MimeMessage();


            emailMessage.From.Add(new MailboxAddress("Админ", "tkachenko.v@routeamgroup.com")); //Указать почту 
            emailMessage.To.Add(new MailboxAddress("Mrs. Chanandler Bong", email)); // изменить на почту 
            emailMessage.Subject = sub;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            //using (var smtpClient = new SmtpClient())
            //{
            //    await smtpClient.ConnectAsync("smtp.yandex.ru", 25 , false);
            ////    await smtpClient.AuthenticateAsync(""); /// ввести данные почты 
            //    await smtpClient.SendAsync(emailMessage);

            //    await smtpClient.DisconnectAsync(true);
            //}

        }

    }
}
