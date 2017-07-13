using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaintSender.Models
{
    public class SendEmailModel
    {
        [Required]
        public String email { get; set; }
        [Required]
        public String body { get; set; }

    }
}