using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using Newspaper.Infra.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {

        private readonly IPageService pageService;

        public PageController(IPageService pageService)
        {
            this.pageService = pageService;
        }

        [HttpGet("GetAllPage")]
        public List<Page> GetAllPage()
        {
            return pageService.GetAllPage();
        }

        [HttpGet("GetPageById/{id}")]
        public Page GetPageById(int id)
        {
            return pageService.GetPageById(id);
        }

        [HttpPost("CreateNewPage")]
        public bool CreateNewPage(Page page)
        {
            return pageService.CreateNewPage(page);
        }

        [HttpPut("UpdatePage")]
        public bool UpdatePage(Page page)
        {
            return pageService.UpdatePage(page);
        }

        [HttpDelete("DeletePage/{id}")]
        public bool DeletePage(int id)
        {
            return pageService.DeletePage(id);
        }
    }
}

