﻿using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace NET02._4
{
    class EmailService
    {
        const string EMAIL_FROM = "vladtest24@gmail.com";
        const string PASSWORD = "vlad12344321";
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Monitoring sites",EMAIL_FROM));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = message
            };
            using(var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync(EMAIL_FROM, PASSWORD);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }      
        }
    }
}
