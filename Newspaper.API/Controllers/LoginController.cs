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
    public class LoginController : ControllerBase
    {

        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }


        [HttpGet("GetAllLogin")]
        public List<Login> GetAllLogin()
        {
            return _loginServices.GetAllLogin();
        }

        [HttpGet("GetLoginById/{id}")]
        public Login GetLoginById(int id)
        {
            return _loginServices.GetLoginById(id);
        }

        [HttpPost("CreateNewLogin")]
        public bool CreateNewLogin(Login login)
        {
            return _loginServices.CreateNewLogin(login);
        }

        [HttpPut("UpdateLogin")]
        public bool UpdateLogin(Login login)
        {
            return _loginServices.UpdateLogin(login);
        }

        [HttpDelete("DeleteLogin/{id}")]
        public bool DeleteLogin(int id)
        {
            return _loginServices.DeleteLogin(id);
        }

        [HttpGet("GetNumberOfUsersByRoleId/{id}")]
        public int GetNumberOfUsersByRoleId(int id) 
        {
            return _loginServices.GetNumberOfUsersByRoleId(id); 
        }

        [HttpGet("GetAllUsersByRoleId/{id}")]
        public Task<List<User>> GetAllUsersByRoleId(int id)
        { 
            return  _loginServices.GetAllUsersByRoleId(id);
        }

        [HttpGet("GetLoginByUserID/{id}")]
        public Login GetLoginByUserID(int id) 
        { 
            return _loginServices.GetLoginByUserID(id); 
        }
    }
}
