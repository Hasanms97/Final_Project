using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Services
{
    public class FavoriteNewsServices : IFavoriteNewsServices
    {
        private readonly IFavoriteNewsRepository _favoriteNewsRepository;

        public FavoriteNewsServices(IFavoriteNewsRepository favoriteNewsRepository)
        {
            _favoriteNewsRepository = favoriteNewsRepository;
        }

        public List<Favoritenews> GetAllFavoriteNews() { return _favoriteNewsRepository.GetAllFavoriteNews(); }
        public Favoritenews GetFavoriteNewsById(int id) { return _favoriteNewsRepository.GetFavoriteNewsById(id); }
        public bool CreateNewFavoriteNews(Favoritenews favoritenews) { return _favoriteNewsRepository.CreateNewFavoriteNews(favoritenews); }
        public bool UpdateFavoriteNews(Favoritenews favoritenews) { return _favoriteNewsRepository.UpdateFavoriteNews(favoritenews); }
        public bool DeleteFavoriteNews(int id) { return _favoriteNewsRepository.DeleteFavoriteNews(id); }

        public Task<List<Category>> DisplayFavoriteNewsForUserId(int id) { return _favoriteNewsRepository.DisplayFavoriteNewsForUserId(id); }
    }
}
