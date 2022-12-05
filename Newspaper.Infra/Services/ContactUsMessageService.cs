using System;
using System.Collections.Generic;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

namespace Newspaper.Infra.Services
{
	public class ContactUsMessageService : IContactUsMessageService

	{
        private readonly IContactUsMessageService contactUsMessageService;

        public ContactUsMessageService(IContactUsMessageService contactUsMessageService)
        {
            this.contactUsMessageService = contactUsMessageService;
        }

        public bool CreateNewOurWebsite(Contactusmessage contactusmessage)
        {
            return contactUsMessageService.CreateNewOurWebsite(contactusmessage);
        }

        public bool DeleteOurWebsite(int id)
        {
            return contactUsMessageService.DeleteOurWebsite(id);
        }

        public List<Contactusmessage> GetAllOurWebsite()
        {
            return contactUsMessageService.GetAllOurWebsite();
        }

        public Contactusmessage GetOurWebsiteById(int id)
        {
            return contactUsMessageService.GetOurWebsiteById(id);
        }

        public bool UpdateOurWebsite(Contactusmessage contactusmessage)
        {
            return contactUsMessageService.UpdateOurWebsite(contactusmessage);
        }
    }
}

