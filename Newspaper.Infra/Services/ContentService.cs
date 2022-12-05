using System;
using System.Collections.Generic;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

namespace Newspaper.Infra.Services
{
	public class ContentService : IContentService
	{
        private readonly IContentRepository contentRepository;

		public ContentService(IContentRepository contentRepository)
		{
            this.contentRepository = contentRepository;
		}

        public bool CreateNewContent(Content Content)
        {
            return contentRepository.CreateNewContent(Content);
        }

        public bool DeleteContent(int id)
        {
            return contentRepository.DeleteContent(id);
        }

        public List<Content> GetAllContent()
        {
            return contentRepository.GetAllContent();
        }

        public Content GetContentById(int id)
        {
            return contentRepository.GetContentById(id);
        }

        public List<Content> GetContentByPageId(int id)
        {
            return contentRepository.GetContentByPageId(id);
        }

        public bool UpdateContent(Content Content)
        {
            return contentRepository.UpdateContent(Content);
        }
    }
}

