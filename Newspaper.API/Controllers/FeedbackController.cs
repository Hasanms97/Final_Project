using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System.Collections.Generic;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackServices _feedbackServices;

        public FeedbackController(IFeedbackServices feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }

        [HttpGet("GetAllFeedback")]
        public List<Feedback> GetAllFeedback() 
        { 
            return _feedbackServices.GetAllFeedback(); 
        }

        [HttpGet("GetFeedbackById/{id}")]
        public Feedback GetFeedbackById(int id) 
        { 
            return _feedbackServices.GetFeedbackById(id); 
        }

        [HttpPost("CreateNewFeedback")]
        public bool CreateNewFeedback(Feedback feedback) 
        { 
            return _feedbackServices.CreateNewFeedback(feedback); 
        }

        [HttpPut("UpdateFeedback")]
        public bool UpdateFeedback(Feedback feedback) 
        { 
            return _feedbackServices.UpdateFeedback(feedback); 
        }

        [HttpDelete("DeleteFeedback/{id}")]
        public bool DeleteFeedback(int id) 
        { 
            return _feedbackServices.DeleteFeedback(id);
        }

        [HttpGet("GetAllFeedbackUnderStudyOfAdmin")]
        public List<Feedback> GetAllFeedbackUnderStudyOfAdmin() 
        { 
            return _feedbackServices.GetAllFeedbackUnderStudyOfAdmin();
        }

        //p(Id -> Feedback , checkadmin)
        [HttpPost("ApproveRejectFeedback")]
        public bool ApproveRejectFeedback(Feedback feedback) 
        { 
            return _feedbackServices.ApproveRejectFeedback(feedback); 
        }
    }
}
