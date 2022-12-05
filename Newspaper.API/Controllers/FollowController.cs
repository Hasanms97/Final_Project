using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    public class FollowController : ControllerBase
    {

        private readonly IFollowService followService;

        public FollowController(IFollowService followService)
        {
            this.followService = followService;
        }

        [HttpGet("GetAllFollow")]
        public List<Follow> GetAllFollow()
        {
            return followService.GetAllFollow();
        }

        [HttpGet("GetFollowById/{id}")]
        public Follow GetFollowById(int id)
        {
            return followService.GetFollowById(id);
        }

        [HttpPost("CreateNewFollow")]
        public bool CreateNewFollow(Follow follow)
        {
            return followService.CreateNewFollow(follow);
        }

        [HttpPut("UpdateFollow")]
        public bool UpdateFollow(Follow follow)
        {
            return followService.UpdateFollow(follow);
        }

        [HttpPost("DeleteFollow/{id}")]
        public bool DeleteFollow(int id)
        {
            return followService.DeleteFollow(id);
        }

        //WARNING JSON
        [HttpGet("CheckFollowers/")]
        public bool CheckFollowers(int p_UserID, int p_PressManID)
        {
            return followService.CheckFollowers(p_UserID, p_PressManID);
        }

        [HttpGet("GetNumberOfFollowers/{p_PressManID}")]
        public int GetNumberOfFollowers(int p_PressManID)
        {
            return followService.GetNumberOfFollowers(p_PressManID);
        }
    }
}

