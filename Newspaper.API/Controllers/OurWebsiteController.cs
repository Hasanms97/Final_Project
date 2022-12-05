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
    public class OurWebsiteController : ControllerBase
    {

        private readonly IOurWebsiteServices _ourWebsiteServices;

        public OurWebsiteController(IOurWebsiteServices ourWebsiteServices)
        {
            _ourWebsiteServices = ourWebsiteServices;
        }


        [HttpGet("GetAllOurWebsite")]
        public List<Ourwebsite> GetAllOurWebsite()
        {
            return _ourWebsiteServices.GetAllOurWebsite();
        }

        [HttpGet("GetOurWebsiteId/{id}")]
        public Ourwebsite GetOurWebsiteId(int id)
        {
            return _ourWebsiteServices.GetOurWebsiteId(id);
        }

        [HttpPost("CreateNewOurWebsite")]
        public bool CreateNewOurWebsite(Ourwebsite ourwebsite)
        {
            return _ourWebsiteServices.CreateNewOurWebsite(ourwebsite);
        }

        [HttpPut("UpdateNewOurWebsite")]
        public bool UpdateNewOurWebsite(Ourwebsite ourwebsite)
        {
            return _ourWebsiteServices.UpdateNewOurWebsite(ourwebsite);
        }

        [HttpDelete("DeleteOurWebsite/{id}")]
        public bool DeleteOurWebsite(int id)
        {
            return _ourWebsiteServices.DeleteOurWebsite(id);
        }

        [HttpPost("UploadImageLogo")]
        public Ourwebsite UploadImageLogo()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/OtherImage/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Ourwebsite ourwebsite = new Ourwebsite();
            ourwebsite.Logopath = fileName;
            return ourwebsite;
        }
    }
}
