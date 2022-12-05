using System;
using Newspaper.Core.Data;
using System.Collections.Generic;

namespace Newspaper.Core.Services
{
	public interface IImageService
	{
        List<Image> GetAllImage();
        List<Image> GetImagesByPageId(int id);
        
        Image GetImageById(int id);
        bool CreateNewImage(Image image);
        bool UpdateImage(Image image);
        bool DeleteImage(int id);
    }
}

