using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsPhotoController : ControllerBase
    {


        private readonly INewsPhotoServices _newsPhotoServices;

        public NewsPhotoController(INewsPhotoServices newsPhotoServices)
        {
            _newsPhotoServices = newsPhotoServices;
        }
        [HttpPost("CreateNewNewsPhoto")]
        public bool CreateNewNewsPhoto(Newsphoto photo)
        {
            return _newsPhotoServices.CreateNewNewsPhoto(photo);
        }
        [HttpPut("UpdateNewsPhoto")]

        public bool UpdateNewsPhoto(Newsphoto photo)
        {
            return _newsPhotoServices.UpdateNewsPhoto(photo);
        }
        [HttpDelete("DeleteNewsPhoto/{id}")]

        public bool DeleteNewsPhoto(int id)
        {
            return _newsPhotoServices.DeleteNewsPhoto(id);
        }

        [HttpGet("GetAllNewsPhotoByNewsId/{newsId}")]
        public List<Newsphoto> GetAllNewsPhotoByNewsId(int newsId)
        {
            return _newsPhotoServices.GetAllNewsPhotoByNewsId(newsId);
        }
        [HttpGet("GetAllPhoto")]  

        public List<Newsphoto> GetAllPhoto()
        {
            return _newsPhotoServices.GetAllPhoto();
        }
        [HttpPost("UploadNewImage")]
        public Newsphoto UploadNewImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/News/Image/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Newsphoto newsphoto = new Newsphoto();
            newsphoto.Imagepath = fileName;
            return newsphoto;
        }
    }
}