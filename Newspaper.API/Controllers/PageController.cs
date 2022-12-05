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

        [HttpGet("GetCategoryById/{id}")]
        public Page GetCategoryById(int id)
        {
            return pageService.GetCategoryById(id);
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

        [HttpPost("DeletePage/{id}")]
        public bool DeletePage(int id)
        {
            return pageService.DeletePage(id);
        }
    }
}

