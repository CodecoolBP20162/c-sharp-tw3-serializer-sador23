using AE.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaintSender.StatePattern;
using SaintSender.DAL;
using SaintSender.Models;

namespace SaintSender.Helpers
{
    public class EmailHandler
    {
        private static State state;

        public static void SendEmail(String body, String email)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add("ycarecoders@gmail.com");
            mailMessage.From = new System.Net.Mail.MailAddress("ycarecoders@gmail.com");
            mailMessage.Subject = "ASP.NET e-mail test";
            mailMessage.Body = body;
            System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("ycarecoders@gmail.com", "Codecool");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        public static Dictionary<string, List<string>> GetMails()
        {
            state = CheckForInternetConnection();
            return state.GetEmails();
        }

        private static State CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return WebState.GetWebState();
                    }
                }
            }
            catch
            {
                return DbState.GetDbState();
            }
        }

        public static void SetIsNextTrue()
        {
            state.SetIsNextTrue();
        }

        public static void SetIsNextFalse()
        {
            state.SetIsNextFalse();
        }

        public static void SaveMails()
        {
            using (var context = new EmailContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Emails]");
            }
            ImapClient ic = new ImapClient("imap.gmail.com", "ycarecoders@gmail.com", "Codecool", AuthMethods.Login, 993, true);
            ic.SelectMailbox("Inbox");

            int countmessages = ic.GetMessageCount();
            MailMessage[] mm = ic.GetMessages(0, countmessages, false);
            using (var db = new EmailContext())
            {
                foreach (MailMessage m in mm)
                {
                    Email email = new Email()
                    {
                        sender = m.From.Address,
                        to = m.To.First().Address,
                        body = m.Body,
                        date = m.Date.ToShortDateString() + " " + m.Date.ToShortTimeString()
                    };
                     db.Emails.Add(email);
                }
                db.SaveChanges();
            }
            ic.Dispose();
        }
    }
}