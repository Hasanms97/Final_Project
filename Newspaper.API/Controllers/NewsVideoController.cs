using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;

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
        [HttpPost("UploadNewVideo")]
        public Newsvideo UploadNewVideo()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/News/Video/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Newsvideo newsvideo = new Newsvideo();
            newsvideo.Videopath = fileName;
            return newsvideo;
        }
    }
}
