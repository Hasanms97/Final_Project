using System;
using Newspaper.Core.Data;
using System.Collections.Generic;

namespace Newspaper.Core.Services
{
	public interface IContactUsMessageService
	{
        List<Contactusmessage> GetAllOurWebsite();
        Contactusmessage GetOurWebsiteById(int id);
        bool CreateNewOurWebsite(Contactusmessage contactusmessage);
        bool UpdateOurWebsite(Contactusmessage contactusmessage);
        bool DeleteOurWebsite(int id);
    }
}

