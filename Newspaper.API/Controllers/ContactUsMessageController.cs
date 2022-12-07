using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using Newspaper.Infra.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsMessageController : ControllerBase
    {
        private readonly IContactUsMessageService contactUsMessageService;

        public ContactUsMessageController(IContactUsMessageService contactUsMessageService)
        {
            this.contactUsMessageService = contactUsMessageService;
        }

        [HttpGet("GetAllOurWebsite")]
        public List<Contactusmessage> GetAllOurWebsite()
        {
            return contactUsMessageService.GetAllOurWebsite();
        }

        [HttpGet("GetOurWebsiteById/{id}")]
        public Contactusmessage GetOurWebsiteById(int id)
        {
            return contactUsMessageService.GetOurWebsiteById(id);
        }

        [HttpPost("CreateNewOurWebsite")]
        public bool CreateNewOurWebsite(Contactusmessage contactusmessage)
        {
            return contactUsMessageService.CreateNewOurWebsite(contactusmessage);
        }

        [HttpPut("UpdateOurWebsite")]
        public bool UpdateOurWebsite(Contactusmessage contactusmessage)
        {
            return contactUsMessageService.UpdateOurWebsite(contactusmessage);
        }

        [HttpGet("DeleteOurWebsite/{id}")]
        public bool DeleteOurWebsite(int id)
        {
            return contactUsMessageService.DeleteOurWebsite(id);
        }
    }
}

