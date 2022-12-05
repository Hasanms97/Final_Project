using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteNewsController : ControllerBase
    {
        private readonly IFavoriteNewsServices _favoriteNewsServices;

        public FavoriteNewsController(IFavoriteNewsServices favoriteNewsServices)
        {
            _favoriteNewsServices = favoriteNewsServices;
        }

        [HttpGet("GetAllFavoriteNews")]
        public List<Favoritenews> GetAllFavoriteNews()
        {
            return _favoriteNewsServices.GetAllFavoriteNews();
        }

        [HttpGet("GetFavoriteNewsById/{id}")]
        public Favoritenews GetFavoriteNewsById(int id)
        {
            return _favoriteNewsServices.GetFavoriteNewsById(id);
        }

        [HttpPost("CreateNewFavoriteNews")]
        public bool CreateNewFavoriteNews(Favoritenews favoritenews)
        {
            return _favoriteNewsServices.CreateNewFavoriteNews(favoritenews);
        }

        [HttpPut("UpdateFavoriteNews")]
        public bool UpdateFavoriteNews(Favoritenews favoritenews)
        {
            return _favoriteNewsServices.UpdateFavoriteNews(favoritenews);
        }

        [HttpDelete("DeleteFavoriteNews/{id}")]
        public bool DeleteFavoriteNews(int id)
        {
            return _favoriteNewsServices.DeleteFavoriteNews(id);
        }

        [HttpGet("DisplayFavoriteNewsForUserId/{id}")]
        public Task<List<Category>> DisplayFavoriteNewsForUserId(int id)
        {
            return _favoriteNewsServices.DisplayFavoriteNewsForUserId(id);
        }
    }
}
