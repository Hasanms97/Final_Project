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
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService contentService;

        public ContentController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        [HttpGet("GetAllContent")]
        public List<Content> GetAllContent()
        {
            return contentService.GetAllContent();
        }

        [HttpGet("GetContentByPageId/{id}")]
        public List<Content> GetContentByPageId(int id)
        {
            return contentService.GetContentByPageId(id);
        }

        [HttpGet("GetContentById/{id}")]
        public Content GetContentById(int id)
        {
            return contentService.GetContentById(id);
        }

        [HttpPost("CreateNewContent")]
        public bool CreateNewContent(Content content)
        {
            return contentService.CreateNewContent(content);
        }

        [HttpPut("UpdateContent")]
        public bool UpdateContent(Content content)
        {
            return contentService.UpdateContent(content);
        }

        [HttpPost("DeleteContent/{id}")]
        public bool DeleteContent(int id)
        {
            return contentService.DeleteContent(id);
        }
    }
}

