using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using MimeKit;
using MailKit.Net.Smtp;

namespace FamousPaintingManagementServices
{
    public class FamousPaintingEmail
    {
        public void SendEmail(string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TheFamousPaintingAdmin", "TFPA@Painting.com"));
            message.To.Add(new MailboxAddress("Editor", "Editor@painting.com"));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var smtpClient = new SmtpClient())
            {
                try
                {
                    smtpClient.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    smtpClient.Authenticate("a631dc2a39c193", "729843081b5600");

                    smtpClient.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    smtpClient.Disconnect(true);
                }
            }
        }

        public void SendPaintingAddedEmail(string paintingTitle)
        {
            string subject = "Famous Painting Management Email - Painting Added Notification";
            string body = "<h1>Good day, User!</h1>" +
                          $"<p>Thank you for adding a new painting titled <strong>{paintingTitle}</strong> to our system.</p>" +
                          "<p><strong>Take care!</strong></p>";
            SendEmail(subject, body);
        }

        public void SendPaintingUpdatedEmail(string paintingTitle)
        {
            string subject = "Famous Painting Management Email - Painting Updated Notification";
            string body = "<h1>Good day, User!</h1>" +
                          $"<p>The painting titled <strong>{paintingTitle}</strong> has been successfully updated.</p>" +
                          "<p><strong>Take care!</strong></p>";
            SendEmail(subject, body);
        }

        public void SendPaintingDeletedEmail(string paintingTitle)
        {
            string subject = "Famous Painting Management Email - Painting Deleted Notification";
            string body = "<h1>Good day, User!</h1>" +
                          $"<p>The painting titled <strong>{paintingTitle}</strong> has been removed from our system.</p>" +
                          "<p><strong>Take care!</strong></p>";
            SendEmail(subject, body);
        }


    }
}




