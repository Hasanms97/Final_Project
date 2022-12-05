using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using Newspaper.Infra.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMailingService _mailingService;

        public UserController(IUserServices userServices, IMailingService mailingService)
        {
            _mailingService = mailingService;
            _userServices = userServices;
        }

        [HttpGet("GetAllUser")]
        public List<User> GetAllUser()
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = "ahmadahmadomari624@gmail.com";
            mailRequest.Subject = "Test";
            mailRequest.Body = "Testaa";
            mailRequest.Attachments = "Files\\ImageUser\\54b84669-39c7-4409-859e-f4511c37afb3_my1.jpg";
            _mailingService.SendEmail(mailRequest);

            return _userServices.GetAllUser();
        }
        
        [HttpGet("GetUserById/{id}")]
        public User GetUserById(int id)
        {
            return _userServices.GetUserById(id);
        }
        
        [HttpPost("CreateNewUser")]
        public bool CreateNewUser(User Use)
        {
            return _userServices.CreateNewUser(Use);
        }
        
        [HttpPut("UpdateUser")]
        public bool UpdateUser(User Use)
        {
            return _userServices.UpdateUser(Use);
        }
        
        [HttpDelete("DeleteUser/{id}")]
        public bool DeleteUser(int id)
        {
            return _userServices.DeleteUser(id);
        }
        
        [HttpGet("GetAllUsersByEmailNotifications")]
        public List<EmailNotificationsDTO> GetAllUsersByEmailNotifications()
        {
            return _userServices.GetAllUsersByEmailNotifications();
        }
        
        [HttpGet("GetAllRequestsAccountPressman")]
        public Task<List<User>> GetAllRequestsAccountPressman()
        {
            return _userServices.GetAllRequestsAccountPressman();
        }
        
        //P(Id -> user , checkAdmin)
        [HttpPost("ApproveRejectAccountPressman")]
        public bool ApproveRejectAccountPressman(User Use)
        {
            return _userServices.ApproveRejectAccountPressman(Use);
        }

        [HttpPost("UploadImageUser")]
        public User UploadImageUser()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/ImageUser/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            User use = new User();
            use.Imagepath = fileName;
            return use;
        }
        
        [HttpPost("UploadJournalistsTestimonialsUser")]
        public User UploadJournalistsTestimonialsUser()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Files/JournalistsTestimonials/", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            User use = new User();
            use.Journalistcertificatepath = fileName;
            return use;
        }

    }
}
