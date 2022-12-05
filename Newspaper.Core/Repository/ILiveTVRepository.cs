using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Repository
{
    public interface ILiveTVRepository
    {
        List<Livetv> GetAllLiveTV();
        Livetv GetLiveTVById(int id);
        bool CreateNewLiveTV(Livetv livetv);
        bool UpdateLiveTV(Livetv livetv);
        bool DeleteLiveTV(int id);
    }
}
