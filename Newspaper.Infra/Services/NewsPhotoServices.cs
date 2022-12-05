using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class NewsPhotoServices :INewsPhotoServices
    {
        private readonly INewsPhotoRepository _newsPhotoRepository;
       

        public NewsPhotoServices(INewsPhotoRepository newsPhotoRepository)
        {
            _newsPhotoRepository = newsPhotoRepository;
        }
        public bool CreateNewNewsPhoto(Newsphoto photo)
        {
            return _newsPhotoRepository.CreateNewNewsPhoto(photo);
        }
        public bool UpdateNewsPhoto(Newsphoto photo)
        {
            return _newsPhotoRepository.UpdateNewsPhoto(photo);
        }
        public bool DeleteNewsPhoto(int id)
        {
            return _newsPhotoRepository.DeleteNewsPhoto(id);
        }

        public List<Newsphoto> GetAllNewsPhotoByNewsId(int newsId)
        {
            return _newsPhotoRepository.GetAllNewsPhotoByNewsId(newsId);
        }
        public List<Newsphoto> GetAllPhoto()
        {
            return _newsPhotoRepository.GetAllPhoto();
        }
    }
}

