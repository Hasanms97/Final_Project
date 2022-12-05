using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {

        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet("GetAllImage")]
        public List<Image> GetAllImage()
        {
            return imageService.GetAllImage();
        }

        [HttpGet("GetImagesByPageId/{id}")]
        public List<Image> GetImagesByPageId(int id)
        {
            return imageService.GetImagesByPageId(id);
        }

        [HttpGet("GetImageById/{id}")]
        public Image GetImageById(int id)
        {
            return imageService.GetImageById(id);
        }

        [HttpGet("CreateNewImage")]
        public bool CreateNewImage(Image image)
        {
            return imageService.CreateNewImage(image);
        }

        [HttpGet("UpdateImage")]
        public bool UpdateImage(Image image)
        {
            return imageService.UpdateImage(image);
        }

        [HttpGet("DeleteImage/{id}")]
        public bool DeleteImage(int id)
        {
            return imageService.DeleteImage(id);
        }
    }
}

