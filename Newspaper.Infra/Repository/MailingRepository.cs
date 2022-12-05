using Microsoft.Extensions.Options;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Repository
{
    public class MailingRepository : IMailingRepository
    {
        private readonly MailSettings _mailSettings;

        public MailingRepository(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public bool SendEmail(MailRequest mailRequest)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            email.To.Add(new MailAddress(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            email.Body = mailRequest.Body;

            SmtpClient smtp = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
            smtp.UseDefaultCredentials = false;

            NetworkCredential nc = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.Credentials = nc;

            smtp.EnableSsl = true;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            email.BodyEncoding = Encoding.UTF8;
            // mR.Attachments ==> attachmentsPath
            if (mailRequest.Attachments != null)
            {
                Attachment attachment = new Attachment(mailRequest.Attachments);
                email.Attachments.Add(attachment);
            }


            bool checkSend = true;
            try
            {
                smtp.SendAsync(email, _mailSettings.DisplayName);
            }
            catch (SmtpFailedRecipientException ex)
            {
                checkSend = false;
            }
            catch (Exception ex)
            {
                checkSend = false;
            }


            return checkSend;
        }
    }
}
