using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class CategoryAdsServices : ICategoryAdsServices
    {
        private readonly ICategoryAdsRepository _categoryAdsRepository;

        public CategoryAdsServices(ICategoryAdsRepository categoryAdsRepository)
        {
            _categoryAdsRepository = categoryAdsRepository;
        }


        public List<Categoryad> GetAllCategoryAds() { return _categoryAdsRepository.GetAllCategoryAds(); }

        public Categoryad GetCategoryAdsById(int id) { return _categoryAdsRepository.GetCategoryAdsById(id); }

        public bool CreateNewCategoryAds(Categoryad categoryad) { return _categoryAdsRepository.CreateNewCategoryAds(categoryad); }

        public bool UpdateCategoryAds(Categoryad categoryad) { return _categoryAdsRepository.UpdateCategoryAds(categoryad); }

        public bool DeleteCategoryAds(int id) { return _categoryAdsRepository.DeleteCategoryAds(id); }

        

        
    }
}
