using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System.Collections.Generic;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeDisLikeController : ControllerBase
    {
        private readonly ILikeDisLikeServices _likeDisLikeServices;
        public LikeDisLikeController(ILikeDisLikeServices likeDisLikeServices)
        {
            _likeDisLikeServices = likeDisLikeServices;
        }
        [HttpPost("CreateNewLikeDisLike")]
        public bool CreateNewLikeDisLike(LikeDislike like)
        {
            return _likeDisLikeServices.CreateNewLikeDisLike(like);

        }
        [HttpPut("UpdateLikeDisLike")]
        public bool UpdateLikeDisLike(LikeDislike like)
        {
            return _likeDisLikeServices.UpdateLikeDisLike(like);
        }
        [HttpDelete("DeleteLikeDisLike/{id}")]
        public bool DeleteLikeDisLike(int id)
        {
            return _likeDisLikeServices.DeleteLikeDisLike(id);
        }
        [HttpGet("GetNumberOfLike/{newsId}")]
        public int GetNumberOfLike(int newsId)
        {
            return _likeDisLikeServices.GetNumberOfLike(newsId);
        }
        [HttpGet("GetNumberOfDisLike/{newsId}")]
        public int GetNumberOfDisLike(int newsId)
        {
            return _likeDisLikeServices.GetNumberOfDisLike(newsId);
        }
        [HttpGet("GetLikeById/{id}")]
        public LikeDislike GetLikeById(int id)
        {
            return _likeDisLikeServices.GetLikeById(id);
        }
        [HttpGet("CheckUserLikeOrDisLike/{newsId}/{userId}")]
        public string CheckUserLikeOrDisLike(int newsId, int userId)
        {
            return _likeDisLikeServices.CheckUserLikeOrDisLike(newsId, userId);
        }

        [HttpGet("GetAllUserLikeDislikeByUserId/{userId}")]

        public List<LikeDislike> GetAllUserLikeDislike(int userId)
        {
            return _likeDisLikeServices.GetAllUserLikeDislike(userId);
        }


    }
}
