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
    public class LiveTVController : ControllerBase
    {
        private readonly ILiveTVServices _liveTVServices;

        public LiveTVController(ILiveTVServices liveTVServices)
        {
            _liveTVServices = liveTVServices;
        }



        [HttpGet("GetAllLiveTV")]
        public List<Livetv> GetAllLiveTV()
        {
            return _liveTVServices.GetAllLiveTV();
        }

        [HttpGet("GetLiveTVById/{id}")]
        public Livetv GetLiveTVById(int id)
        {
            return _liveTVServices.GetLiveTVById(id);
        }

        [HttpPost("CreateNewLiveTV")]
        public bool CreateNewLiveTV(Livetv livetv)
        {
            return _liveTVServices.CreateNewLiveTV(livetv);
        }

        [HttpPut("UpdateLiveTV")]
        public bool UpdateLiveTV(Livetv livetv)
        {
            return _liveTVServices.UpdateLiveTV(livetv);
        }

        [HttpDelete("DeleteLiveTV/{id}")]
        public bool DeleteLiveTV(int id)
        {
            return _liveTVServices.DeleteLiveTV(id);
        }

        [HttpPost("UploadImageTV")]
        public Livetv UploadImageTV()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/ImageTV/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Livetv livetv = new Livetv();
            livetv.Imagepath = fileName;
            return livetv;
        }
    }
}
