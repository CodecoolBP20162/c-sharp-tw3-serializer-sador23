using AE.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaintSender.StatePattern
{
    public class WebState : State
    {
        private static WebState instance = null;
        private int currentPage;
        private bool IsNext;

        public Dictionary<string, List<string>> GetEmails()
        {
            //Decalre the needed variables
            Dictionary<String, List<String>> map = new Dictionary<string, List<string>>();
            List<String> allSenders = new List<string>();
            List<String> allMessages = new List<String>();
            List<String> allTo = new List<string>();
            List<String> allDate = new List<string>();

            //Add the lists to the dictionary
            map.Add("sender", allSenders);
            map.Add("message", allMessages);
            map.Add("To", allTo);
            map.Add("Date", allDate);

            ImapClient ic = new ImapClient("imap.gmail.com", "ycarecoders@gmail.com", "Codecool", AuthMethods.Login, 993, true);
            ic.SelectMailbox("Inbox");

            int countmessages = ic.GetMessageCount();
            MailMessage[] mm;
            if (IsNext)
            {
                mm = ic.GetMessages(currentPage, currentPage + 30, false);
            }
            else
            {
                mm = ic.GetMessages(currentPage - 30, currentPage, false);
            }
            foreach (MailMessage m in mm)
            {
                allSenders.Add(m.From.Address);
                allTo.Add(m.To.First().Address);
                allMessages.Add(m.Body);
                allDate.Add(m.Date.ToShortDateString() + " " + m.Date.ToShortTimeString());
            }

            ic.Dispose();
            return map;
        }

        private WebState()
        {
            IsNext = true;
            currentPage = 0;
        }

        public static WebState GetWebState()
        {
            if (instance == null) instance = new WebState();
            return instance;
        }

        public void SetIsNextTrue()
        {
            currentPage += 30;
            IsNext = true;
        }

        public void SetIsNextFalse()
        {
            currentPage -= 30;
            if (currentPage < 0) currentPage = 0;
            IsNext = false;
        }
    }
}