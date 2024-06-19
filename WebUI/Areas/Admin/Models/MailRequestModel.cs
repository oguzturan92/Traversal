using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;

namespace WebUI.Areas.Admin.Models
{
    public class MailRequestModel
    {
        public string SenderName { get; set; }
        public string SenderMail { get; set; }
        public string SenderMailPassword { get; set; }
        public string SenderMailHost { get; set; }
        public int SenderMailPort { get; set; }
        public bool SenderMailEnableSSL { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}