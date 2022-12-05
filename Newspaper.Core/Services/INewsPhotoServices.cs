using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Services
{
    public interface INewsPhotoServices
    {

        bool CreateNewNewsPhoto(Newsphoto photo);
        bool UpdateNewsPhoto(Newsphoto photo);
        bool DeleteNewsPhoto(int id);

        public List<Newsphoto> GetAllNewsPhotoByNewsId(int newsId);
        List<Newsphoto> GetAllPhoto();
    }
}
