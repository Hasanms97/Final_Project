using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class NewsServices : INewsServices
    {
        private readonly INewsRepository newsRepository;

        public NewsServices(INewsRepository _newsRepository)
        {
            newsRepository = _newsRepository;
        }

        public bool CreateNewNews(News news)
        {
            return newsRepository.CreateNewNews(news);

        }
        public bool UpdateNews(News news)
        {

            return newsRepository.UpdateNews(news);
        }
        public bool DeleteNews(int id)
        {
            return newsRepository.DeleteNews(id);


        }
        public bool ApprovOrRejectNews(int id, string AdminCheck)
        {
            return newsRepository.ApprovOrRejectNews(id, AdminCheck);

        }

        public List<News> GetAllNews()
        {
            return newsRepository.GetAllNews();
        }
        public News GetNewsById(int id)
        {
            return newsRepository.GetNewsById(id);
        }
        public List<News> GetAllInProgressNew()
        {
            return newsRepository.GetAllInProgressNew();
        }
    }
}
