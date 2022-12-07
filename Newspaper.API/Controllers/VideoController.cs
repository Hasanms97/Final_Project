using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("CreateNewVideo")]
        public bool CreateNewVideo(Video video)
        {
            return videoService.CreateNewVideo(video);
        }

        [HttpPut("UpdateVideo")]
        public bool UpdateVideo(Video video)
        {
            return videoService.UpdateVideo(video);
        }

        [HttpDelete("DeleteVideo/{id}")]
        public bool DeleteVideo(int id)
        {
            return videoService.DeleteVideo(id);
        }

        [HttpPost("UploadVideo")]
        public Video UploadVideo()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/Page/Video/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Video video = new Video();
            video.Videopath = fileName;
            return video;
        }
    }
}

