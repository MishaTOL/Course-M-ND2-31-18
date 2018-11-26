using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Lab4
{
    internal class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {

            // настройка логина, пароля отправителя
            var from = "xbestya@yandex.ru";
            var pass = "";

            SmtpClient client = new SmtpClient("smtp.yandex.ru", 25);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pass);
            client.EnableSsl = true;

            var mail = new MailMessage(from, message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.IsBodyHtml = true;

            return client.SendMailAsync(mail);
            //return Task.FromResult(0);
        }
    }
}