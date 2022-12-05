using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Repository
{
    public interface IOurWebsiteRepository
    {
        List<Ourwebsite> GetAllOurWebsite();
        Ourwebsite GetOurWebsiteId(int id);
        bool CreateNewOurWebsite(Ourwebsite ourwebsite);
        bool UpdateNewOurWebsite(Ourwebsite ourwebsite);
        bool DeleteOurWebsite(int id);
    }
}
