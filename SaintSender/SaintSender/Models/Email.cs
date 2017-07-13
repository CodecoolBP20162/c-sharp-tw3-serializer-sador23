using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaintSender.Models
{
    public class Email
    {
        [Key]
        public int ID { get; set; }

        public String sender { get; set; }
        public String body { get; set; }
        public String to { get; set; }
        public String date { get; set; }
    }

   
}