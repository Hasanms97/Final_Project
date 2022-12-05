using System;
using Newspaper.Core.Data;
using System.Collections.Generic;

namespace Newspaper.Core.Services
{
	public interface IContentService
	{
        List<Content> GetAllContent();
        List<Content> GetContentByPageId(int id);
        Content GetContentById(int id);

        bool CreateNewContent(Content Content);
        bool UpdateContent(Content Content);
        bool DeleteContent(int id);
    }
}

