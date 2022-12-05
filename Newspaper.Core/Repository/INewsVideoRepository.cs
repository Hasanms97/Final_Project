using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Repository
{
    public interface INewsVideoRepository
    {
        bool CreateNewNewsVideo(Newsvideo video);
        bool UpdateNewsVideo(Newsvideo video);
        bool DeleteNewsVideo(int id);

        public List<Newsvideo> GetAllNewsVideoByNewsId(int newsId);
        List<Newsvideo> GetAllVideo();

    }
}
