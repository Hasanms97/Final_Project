using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Repository
{
    public interface ICategoryAdsRepository
    {
        List<Categoryad> GetAllCategoryAds();
        Categoryad GetCategoryAdsById(int id);
        bool CreateNewCategoryAds(Categoryad categoryad);
        bool UpdateCategoryAds(Categoryad categoryad);
        bool DeleteCategoryAds(int id);
    }
}
