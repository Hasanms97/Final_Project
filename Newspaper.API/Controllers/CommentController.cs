using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentServices _comentServices;


        public CommentController(ICommentServices commentServices)
        {
            _comentServices = commentServices;

        }



        [HttpPost("CreateNewComment")]
        public bool CreateNewComment(Commentt comment)
        {

            return _comentServices.CreateNewComment(comment);   

        }
        [HttpPut("UpdateComment")]
        public bool UpdateComment(Commentt comment)
        {
            return _comentServices.UpdateComment(comment);
        }
        [HttpDelete("DeleteComment/{id}")]

        public bool DeleteComment(int id)
        {
            return _comentServices.DeleteComment(id);
        }

        [HttpGet("GetAllNumberOfComments/{newsId}")]

        public int GetAllNumberOfComments(int newsId)
        {
            return _comentServices.GetAllNumberOfComments(newsId);
        }
        [HttpGet("GetCommentById/{id}")]

        public News GetCommentById(int id)
        {
            return _comentServices.GetCommentById(id);
        }

        [HttpGet("GetAllNewsComments/{newsId}")]
        public Task<List<Commentt>> GetAllNewsComments(int newsId)
        {
            return _comentServices.GetAllNewsComments(newsId);
        }

        [HttpGet("GetAllUsersComments/{userId}")]
        public List<Commentt> GetAllUsersComments(int userId) 
        {
            return _comentServices.GetAllUsersComments(userId); 
        }

    }
}
