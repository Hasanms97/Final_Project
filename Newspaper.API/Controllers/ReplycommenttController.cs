using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    public class ReplycommenttController : ControllerBase
    {
        private readonly IReplayCommentService replayCommentService;

        public ReplycommenttController(IReplayCommentService replayCommentService)
        {
            this.replayCommentService = replayCommentService;
        }

        [HttpPost("CreateNewReplayComment")]
        public bool CreateNewReplayComment(Replycommentt replycommentt)
        {
            return replayCommentService.CreateNewReplayComment(replycommentt);
        }

        [HttpPost("DeleteReplayComment")]
        public bool DeleteReplayComment(int id)
        {
            return replayCommentService.DeleteReplayComment(id);
        }

        [HttpGet("GetAllReplayComment")]
        public List<Replycommentt> GetAllReplayComment()
        {
            return replayCommentService.GetAllReplayComment();
        }

        [HttpGet("GetAllReplayCommentOnComment")]
        public List<Replycommentt> GetAllReplayCommentOnComment(int id)
        {
            return replayCommentService.GetAllReplayCommentOnComment(id);
        }

        [HttpGet("GetReplayCommentById")]
        public Replycommentt GetReplayCommentById(int id)
        {
            return replayCommentService.GetReplayCommentById(id);
        }

        [HttpPut("UpdateReplayComment")]
        public bool UpdateReplayComment(Replycommentt replycommentt)
        {
            return replayCommentService.UpdateReplayComment(replycommentt);
        }
    }
}

