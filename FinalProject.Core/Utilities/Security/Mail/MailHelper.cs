using Microsoft.AspNetCore.Hosting;
using FinalProject.Core.Utilities.Security.Hashing;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace FinalProject.Core.Utilities.Security.Mail
{
    public class MailHelper
    {
        
        private readonly EmailConfiguration _emailConfiguration;
        private readonly IWebHostEnvironment _env;

        public MailHelper(EmailConfiguration emailConfiguration, IWebHostEnvironment env)
        {
            _emailConfiguration = emailConfiguration;
            _env = env;
        }


        public void SendMail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailConfiguration.From);
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Content;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfiguration.Username, _emailConfiguration.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        public string ConfirmationMailContent(string email)
        {
            email = HashString.Encode(email);
            string url = $"https://localhost:44398/employee/confirmation/{email}";
            return string.Format(@$"<div style='text-align: center; margin-top:50px; height:100vh;'>
                                          <h1 style='text-align: center; color:rgb(15, 166, 226)'>Xəstəxana İdarəetmə Sistemi</h1>
                                          <h3 style='text-align: center; color:rgb(37, 113, 143)'>Aşağıdakı düyməyə klikləyib hesabınızı aktivləşdirin.</h3>
                                          <a href='{url}' style='padding: 10px 100px;
                                                                 text-decoration:none;
                                                                 cursor: pointer;
                                                                 border: none;
                                                                 font-size: 18px;
                                                                 background-color: rgb(51, 93, 110);
                                                                 color: white;
                                                                 border-radius: 20px;'>
                                                   Aktivləşdir
                                         </a>
                                    </div>

", email);
        }

        public string ResetPasswordMailContent(string email)
        {
            email = HashString.Encode(email);
            string url = $"http://localhost:3000/resetpassword/?email={email}";
            return string.Format(@$"<div style='text-align: center; margin-top:50px; height:100vh;'>
                                          <h1 style='text-align: center; color:rgb(15, 166, 226)'>Xəstəxana İdarəetmə Sistemi</h1>
                                          <h3 style='text-align: center; color:rgb(37, 113, 143)'>Aşağıdakı düyməyə klikləyib şifrənizi sıfırlayın.</h3>
                                          <a href='{url}' style='padding: 10px 100px;
                                                                 text-decoration:none;
                                                                 cursor: pointer;
                                                                 border: none;
                                                                 font-size: 18px;
                                                                 background-color: rgb(51, 93, 110);
                                                                 color: white;
                                                                 border-radius: 20px;'>
                                                   Şifrəni sıfırla
                                         </a>
                                    </div>

", email);
        }

        public string SuccessConfirmation()
        {
           return string.Format($@"<body style='padding:0;margin:0;'><img style='width: 100%; height: 100vh;' src='https://uploads-ssl.webflow.com/5ec6a62e9bc69b489371e3e6/6198c041d234856b72588d1b_ai2shais_blog_confirmationmail.png'></body>");
        }
    }
}
