using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class LikeDisLikeServices :ILikeDisLikeServices
    {
        private readonly ILikeDisLikeRepository _likeDisLikeRepository;
        public LikeDisLikeServices(ILikeDisLikeRepository likeDisLikeRepository)
        {
            _likeDisLikeRepository = likeDisLikeRepository;
        }
        public bool CreateNewLikeDisLike(LikeDislike like)
        {
            return _likeDisLikeRepository.CreateNewLikeDisLike(like);

        }
        public bool UpdateLikeDisLike(LikeDislike like)
        {
            return _likeDisLikeRepository.UpdateLikeDisLike(like);
        }
        public bool DeleteLikeDisLike(int id)
        {
            return _likeDisLikeRepository.DeleteLikeDisLike(id);
        }
        public int GetNumberOfLike(int newsId)
        {
            return _likeDisLikeRepository.GetNumberOfLike(newsId);
        }
        public int GetNumberOfDisLike(int newsId)
        {
            return _likeDisLikeRepository.GetNumberOfDisLike(newsId);
        }

        public LikeDislike GetLikeById(int id)
        {
            return _likeDisLikeRepository.GetLikeById(id);
        }
        public string CheckUserLikeOrDisLike(int newsId, int userId)
        {
            return _likeDisLikeRepository.CheckUserLikeOrDisLike(newsId, userId);
        }
        public List<LikeDislike> GetAllUserLikeDislike(int userId)
        {
            return _likeDisLikeRepository.GetAllUserLikeDislike(userId);
        }

    }
}
