using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System.Collections.Generic;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAdsController : ControllerBase
    {
        private readonly ICategoryAdsServices _categoryAdsServices;

        public CategoryAdsController(ICategoryAdsServices categoryAdsServices)
        {
            _categoryAdsServices = categoryAdsServices;
        }

        [HttpGet("GetAllCategoryAds")]
        public List<Categoryad> GetAllCategoryAds()
        {
            return _categoryAdsServices.GetAllCategoryAds();
        }

        [HttpGet("GetCategoryAdsById/{id}")]
        public Categoryad GetCategoryAdsById(int id)
        {
            return _categoryAdsServices.GetCategoryAdsById(id);
        }

        [HttpPost("CreateNewCategoryAds")]
        public bool CreateNewCategoryAds(Categoryad categoryad)
        {
            return _categoryAdsServices.CreateNewCategoryAds(categoryad);
        }

        [HttpPut("UpdateCategoryAds")]
        public bool UpdateCategoryAds(Categoryad categoryad)
        {
            return _categoryAdsServices.UpdateCategoryAds(categoryad);
        }

        [HttpDelete("DeleteCategoryAds/{id}")]
        public bool DeleteCategoryAds(int id)
        {
            return _categoryAdsServices.DeleteCategoryAds(id);
        }
    }
}
