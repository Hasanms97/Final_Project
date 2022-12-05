using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System.Collections.Generic;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsVideoController : ControllerBase
    {

        private readonly INewsVideoServices _newsVideoServices;
    
        public NewsVideoController(INewsVideoServices newsVideoServices)
        {
            _newsVideoServices = newsVideoServices;
        }
        [HttpPost("CreateNewNewsVideo")]
        public bool CreateNewNewsVideo(Newsvideo video)
        {
            return _newsVideoServices.CreateNewNewsVideo(video);
        }
        [HttpPut("UpdateNewsVideo")]
        public bool UpdateNewsVideo(Newsvideo video)
        {
            return _newsVideoServices.UpdateNewsVideo(video);
        }
        [HttpDelete("DeleteNewsVideo/{id}")]
        public bool DeleteNewsVideo(int id)
        {
            return _newsVideoServices.DeleteNewsVideo(id);
        }
        [HttpGet("GetAllNewsVideoByNewsId/{newsId}")]
        public List<Newsvideo> GetAllNewsVideoByNewsId(int newsId)
        {
            return _newsVideoServices.GetAllNewsVideoByNewsId(newsId);
        }
        [HttpGet("GetAllVideo")]
        public List<Newsvideo> GetAllVideo()
        {
            return _newsVideoServices.GetAllVideo();

        }


    }
}
