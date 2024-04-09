using Microsoft.EntityFrameworkCore.Storage;
using System.Net;
using System.Net.Mail;

namespace WebSupport.NotifyMail
{
    public class MessageSender
    {
        public void Send(string reciever = "poo1i@yandex.ru", string subject ="Попытка 2", string message= "я узкий")
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();

            string passwrodSender = configuration["PasswordMail"].ToString();
            string usernameSender = configuration["SenderMail"].ToString();

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(usernameSender, passwrodSender),
                EnableSsl = true,
            };
            smtpClient.Send(usernameSender, reciever, subject, message);
        }



    }
}
