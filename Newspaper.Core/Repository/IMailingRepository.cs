using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Core.Repository
{
    public interface IMailingRepository
    {
        bool SendEmail(MailRequest mailRequest);
    }
}
