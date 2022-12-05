using System;
using System.Collections.Generic;
using Newspaper.Core.Data;

namespace Newspaper.Core.Repository
{
	public interface IImageRepository
	{
        List<Image> GetAllImage();
        List<Image> GetImagesByPageId(int id);

        Image GetImageById(int id);
        bool CreateNewImage(Image image);
        bool UpdateImage(Image image);
        bool DeleteImage(int id);
    }
}

