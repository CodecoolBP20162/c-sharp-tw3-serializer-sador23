using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenPop.Pop3;
using OpenPop.Mime;
using AE.Net.Mail;
using SaintSender.Helpers;
using SaintSender.Models;
using SaintSender.StatePattern;
using SaintSender.DAL;

namespace SaintSender.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            Dictionary<String, List<String>> map = EmailHandler.GetMails();
            
            return View(map);
        }

        public ActionResult Next()
        {
            EmailHandler.SetIsNextTrue();
            Dictionary<String, List<String>> map = EmailHandler.GetMails();
            return View("Index",map);
        }
        public ActionResult Previous()
        {
            EmailHandler.SetIsNextFalse();
            Dictionary<String, List<String>> map = EmailHandler.GetMails();
            return View("Index", map);
        }

        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(SendEmailModel model)
        {
            Dictionary<String, List<String>> map = EmailHandler.GetMails();
            if (ModelState.IsValid)
            {
                try
                {
                    EmailHandler.SendEmail(model.body, model.email);
                }catch( Exception e)
                {
                    map["To"][0] =(e.Message);
                }
            }
            return View("Index", map);
        }

        public ActionResult SaveEmails()
        {
            Dictionary<String, List<String>> map = EmailHandler.GetMails();
            return View("Index",map);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}