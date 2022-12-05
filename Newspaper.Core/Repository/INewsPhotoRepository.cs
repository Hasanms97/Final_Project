using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Core.Repository
{
    public interface INewsPhotoRepository
    {


        bool CreateNewNewsPhoto(Newsphoto photo);
        bool UpdateNewsPhoto(Newsphoto photo);
        bool DeleteNewsPhoto(int id);

        public List<Newsphoto> GetAllNewsPhotoByNewsId(int newsId);
        List<Newsphoto> GetAllPhoto();
    }
}
