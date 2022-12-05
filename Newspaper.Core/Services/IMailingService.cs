using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Core.Services
{
    public interface IMailingService
    {
        bool SendEmail(MailRequest mailRequest);
    }
}
