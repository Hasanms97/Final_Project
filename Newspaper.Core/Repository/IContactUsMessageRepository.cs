using System;
using Newspaper.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newspaper.Core.Repository
{
	public interface IContactUsMessageRepository
	{
        List<Contactusmessage>GetAllOurWebsite();
        Contactusmessage GetOurWebsiteById(int id);
        bool CreateNewOurWebsite(Contactusmessage contactusmessage);
        bool UpdateOurWebsite(Contactusmessage contactusmessage);
        bool DeleteOurWebsite(int id);
    }
}

