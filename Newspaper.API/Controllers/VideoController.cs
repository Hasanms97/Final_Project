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
    public class VideoController : ControllerBase
    {
        private readonly IVideoService videoService;

        public VideoController(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        [HttpGet("GetAllVideo")]
        public List<Video> GetAllVideo()
        {
            return videoService.GetAllVideo();
        }

        [HttpGet("GetViedosByPageId/{id}")]
        public List<Video> GetViedosByPageId(int id)
        {
            return videoService.GetViedosByPageId(id);
        }

        [HttpGet("GetVideoById/{id}")]
        public Video GetVideoById(int id)
        {
            return videoService.GetVideoById(id);
        }

        [HttpGet("CreateNewVideo")]
        public bool CreateNewVideo(Video video)
        {
            return videoService.CreateNewVideo(video);
        }

        [HttpGet("UpdateVideo")]
        public bool UpdateVideo(Video video)
        {
            return videoService.UpdateVideo(video);
        }

        [HttpGet("DeleteVideo/{id}")]
        public bool DeleteVideo(int id)
        {
            return videoService.DeleteVideo(id);
        }
    }
}

