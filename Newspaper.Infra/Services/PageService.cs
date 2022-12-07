using System;
using System.Collections.Generic;
using Azure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using Page = Newspaper.Core.Data.Page;

namespace Newspaper.Infra.Services
{
	public class PageService : IPageService
	{
        private readonly IPageRepository pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            this.pageRepository = pageRepository;
        }

        public bool CreateNewPage(Page page)
        {
            return pageRepository.CreateNewPage(page);
        }

        public bool DeletePage(int id)
        {
            return pageRepository.DeletePage(id);
        }

        public List<Page> GetAllPage()
        {
            return pageRepository.GetAllPage();
        }

        public Page GetPageById(int id)
        {
            return pageRepository.GetPageById(id);
        }

        public bool UpdatePage(Page page)
        {
            return pageRepository.UpdatePage(page);
        }
    }
}

