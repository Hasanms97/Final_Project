using System;
using Newspaper.Core.Data;
using System.Collections.Generic;

namespace Newspaper.Core.Repository
{
	public interface IPageRepository
	{
        List<Page> GetAllPage();
        Page GetPageById(int id);
        bool CreateNewPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(int id);
    }
}

