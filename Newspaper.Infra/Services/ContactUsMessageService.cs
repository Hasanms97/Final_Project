using System;
using System.Collections.Generic;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

namespace Newspaper.Infra.Services
{
	public class ContactUsMessageService : IContactUsMessageService

	{
        private readonly IContactUsMessageRepository contactUsMessageRepository;

        public ContactUsMessageService(IContactUsMessageRepository contactUsMessageRepository)
        {
            this.contactUsMessageRepository = contactUsMessageRepository;
        }

        public bool CreateNewOurWebsite(Contactusmessage contactusmessage)
        {
            return contactUsMessageRepository.CreateNewOurWebsite(contactusmessage);
        }

        public bool DeleteOurWebsite(int id)
        {
            return contactUsMessageRepository.DeleteOurWebsite(id);
        }

        public List<Contactusmessage> GetAllOurWebsite()
        {
            return contactUsMessageRepository.GetAllOurWebsite();
        }

        public Contactusmessage GetOurWebsiteById(int id)
        {
            return contactUsMessageRepository.GetOurWebsiteById(id);
        }

        public bool UpdateOurWebsite(Contactusmessage contactusmessage)
        {
            return contactUsMessageRepository.UpdateOurWebsite(contactusmessage);
        }
    }
}

