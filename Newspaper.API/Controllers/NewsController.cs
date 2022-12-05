using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using Newspaper.Infra.Repository;
using System.Collections.Generic;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly INewsServices _NewsServices;
      

        public NewsController(INewsServices NewsServices)
        {
            _NewsServices = NewsServices;
           
        }


        [HttpPost("CreateNewNews")]
        public bool CreateNewNews(News news)
        {
            return _NewsServices.CreateNewNews(news);

        }
        [HttpPut("UpdateNews")]
        public bool UpdateNews(News news)
        {

            return _NewsServices.UpdateNews(news);
        }
        [HttpDelete("DeleteNews/{id}")]
        public bool DeleteNews(int id)
        {
            return _NewsServices.DeleteNews(id);


        }
        [HttpPut("ApprovOrRejectNews")]
        public bool ApprovOrRejectNews(News news)
        {
            return _NewsServices.ApprovOrRejectNews((int)news.Id, news.Checkadmin);

        }
        [HttpGet("GetAllNews")]
        public List<News> GetAllNews()
        {
            return _NewsServices.GetAllNews();
        }
        [HttpGet("GetNewsById/{id}")]
        public News GetNewsById(int id)
        {
            return _NewsServices.GetNewsById(id);
        }
        [HttpGet("GetAllInProgressNew")]
        public List<News> GetAllInProgressNew()
        {
            return _NewsServices.GetAllInProgressNew();
        }

    }
}
