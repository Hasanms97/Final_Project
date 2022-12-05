using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Newspaper.Core.Data
{
    public class MailRequest
    {
        [Required]
        public string ToEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }

        // mR.Attachments ==> attachmentsPath
        public string Attachments { get; set; }
    }
}
