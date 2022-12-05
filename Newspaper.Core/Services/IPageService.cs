using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newspaper.Core.Data;
using Page = Newspaper.Core.Data.Page;

namespace Newspaper.Core.Services
{
	public interface IPageService
	{
        List<Page> GetAllPage();
        Page GetCategoryById(int id);
        bool CreateNewPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(int id);
    }
}

