using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Core.Services
{
    public interface IFavoriteNewsServices
    {
        List<Favoritenews> GetAllFavoriteNews();
        Favoritenews GetFavoriteNewsById(int id);
        bool CreateNewFavoriteNews(Favoritenews favoritenews);
        bool UpdateFavoriteNews(Favoritenews favoritenews);
        bool DeleteFavoriteNews(int id);

        Task<List<Category>> DisplayFavoriteNewsForUserId(int id);
    }
}
