using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class OurWebsiteServices : IOurWebsiteServices
    {
        private readonly IOurWebsiteRepository _ourWebsiteRepository;

        public OurWebsiteServices(IOurWebsiteRepository ourWebsiteRepository)
        {
            _ourWebsiteRepository = ourWebsiteRepository;
        }

        public List<Ourwebsite> GetAllOurWebsite() { return _ourWebsiteRepository.GetAllOurWebsite(); }
        public Ourwebsite GetOurWebsiteId(int id) { return _ourWebsiteRepository.GetOurWebsiteId(id); }
        public bool CreateNewOurWebsite(Ourwebsite ourwebsite) { return _ourWebsiteRepository.CreateNewOurWebsite(ourwebsite); }
        public bool UpdateNewOurWebsite(Ourwebsite ourwebsite) { return _ourWebsiteRepository.UpdateNewOurWebsite(ourwebsite); }
        public bool DeleteOurWebsite(int id) { return _ourWebsiteRepository.DeleteOurWebsite(id); }
    }
}
