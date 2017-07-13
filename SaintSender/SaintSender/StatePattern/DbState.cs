using System;
using System.Collections.Generic;
using System.Linq;
using SaintSender.Models;
using SaintSender.DAL;

namespace SaintSender.StatePattern
{
    public class DbState : State
    {

        private static DbState instance = null;
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
            using (var context = new EmailContext())
            {
                if (IsNext)
                {
                    var mails = from m in context.Emails
                                where m.ID > (currentPage - 1) && m.ID < (currentPage + 31)
                                select m;
                    foreach (Email mail in mails)
                    {
                        allSenders.Add(mail.sender);
                        allTo.Add(mail.to);
                        allMessages.Add(mail.body);
                        allDate.Add(mail.date);
                    }
                }
                else
                {
                    var mails = from m in context.Emails
                                where m.ID > currentPage - 31 && m.ID < currentPage + 1
                                select m;
                    foreach (Email mail in mails)
                    {
                        allSenders.Add(mail.sender);
                        allTo.Add(mail.to);
                        allMessages.Add(mail.body);
                        allDate.Add(mail.date);
                    }
                }
            }
           
            return map;
            
        }

        private IQueryable<Email> MailQuery()
        {
            using (var context = new EmailContext())
            {
                if (IsNext)
                {
                    var mails = from m in context.Emails
                                where m.ID >( currentPage -1) && m.ID < (currentPage + 31)
                                select m;
                    return mails;
                }
                else
                {
                    var mails = from m in context.Emails
                                where m.ID > currentPage || m.ID < (currentPage -30)
                                select m;
                    return mails;
                }
            }
        }

        private DbState()
        {
            IsNext = true;
            currentPage = 0;
        }

        public static DbState GetDbState() {
            if (instance == null) instance = new DbState();
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