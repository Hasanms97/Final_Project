using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class LiveTVServices : ILiveTVServices
    {
        private readonly ILiveTVRepository _liveTVRepository;

        public LiveTVServices(ILiveTVRepository liveTVRepository)
        {
            _liveTVRepository = liveTVRepository;
        }

        public List<Livetv> GetAllLiveTV() { return _liveTVRepository.GetAllLiveTV(); }
        public Livetv GetLiveTVById(int id) { return _liveTVRepository.GetLiveTVById(id); }
        public bool CreateNewLiveTV(Livetv livetv) { return _liveTVRepository.CreateNewLiveTV(livetv); }
        public bool UpdateLiveTV(Livetv livetv) { return _liveTVRepository.UpdateLiveTV(livetv); }
        public bool DeleteLiveTV(int id) { return _liveTVRepository.DeleteLiveTV(id); }
    }
}
