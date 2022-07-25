using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Utilities.Security.Mail
{
    public class MailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public bool IsHtmlBody { get; set; }
        public string Content { get; set; }
    }
}
