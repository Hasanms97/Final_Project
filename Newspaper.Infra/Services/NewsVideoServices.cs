using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class NewsVideoServices :INewsVideoServices
    {

        private readonly INewsVideoRepository _newsVideoRepository;


        public NewsVideoServices(INewsVideoRepository newsVideoRepository)
        {
            _newsVideoRepository = newsVideoRepository;
        }
        public bool CreateNewNewsVideo(Newsvideo video)
        {
            return _newsVideoRepository.CreateNewNewsVideo(video);  
        }
        public bool UpdateNewsVideo(Newsvideo video)
        {
            return _newsVideoRepository.UpdateNewsVideo(video);
        }
        public bool DeleteNewsVideo(int id)
        {
            return _newsVideoRepository.DeleteNewsVideo(id);
        }

        public  List<Newsvideo> GetAllNewsVideoByNewsId(int newsId)
        {
            return _newsVideoRepository.GetAllNewsVideoByNewsId(newsId);
        }
        public List<Newsvideo> GetAllVideo()
        {
            return _newsVideoRepository.GetAllVideo();  

        }
    }
}
