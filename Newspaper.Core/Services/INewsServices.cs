using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Services
{
    public interface INewsServices
    {
        bool CreateNewNews(News news);
        bool UpdateNews(News news);
        bool DeleteNews(int id);
        bool ApprovOrRejectNews(int id, string AdminCheck);

        List<News> GetAllNews();
        News GetNewsById(int id);
        List<News> GetAllInProgressNew();

    }
}
