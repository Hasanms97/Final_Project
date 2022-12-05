using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Services
{
    public class MailingService : IMailingService
    {
        private readonly IMailingRepository _mailingRepository;

        public MailingService(IMailingRepository mailingRepository)
        {
            _mailingRepository = mailingRepository;
        }

        public bool SendEmail(MailRequest mailRequest)
        {
             return _mailingRepository.SendEmail(mailRequest);
        }
    }
}
