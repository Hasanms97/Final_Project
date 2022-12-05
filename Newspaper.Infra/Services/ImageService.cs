using System;
using System.Collections.Generic;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

namespace Newspaper.Infra.Services
{
	public class ImageService : IImageService
	{
        private readonly IImageRepository imageRepository;

		public ImageService(IImageRepository imageRepository)
		{
            this.imageRepository = imageRepository;
        }

        public bool CreateNewImage(Image image)
        {
            return imageRepository.CreateNewImage(image);
        }

        public bool DeleteImage(int id)
        {
            return imageRepository.DeleteImage(id);
        }

        public List<Image> GetAllImage()
        {
            return imageRepository.GetAllImage();
        }

        public Image GetImageById(int id)
        {
            return imageRepository.GetImageById(id);
        }

        public List<Image> GetImagesByPageId(int id)
        {
            return imageRepository.GetImagesByPageId(id);
        }

        public bool UpdateImage(Image image)
        {
            return imageRepository.UpdateImage(image);
        }
    }
}

