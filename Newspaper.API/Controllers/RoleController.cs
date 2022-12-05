using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;
using System.Collections.Generic;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleServices _roleServices;

        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [HttpGet("GetAllRole")]
        public List<Role> GetAllRole()
        {
            return _roleServices.GetAllRole();
        }

        [HttpGet("GetRoleById/{id}")]
        public Role GetRoleById(int id)
        {
            return _roleServices.GetRoleById(id);
        }

        [HttpPost("CreateNewRole")]
        public bool CreateNewRole(Role role)
        {
            return _roleServices.CreateNewRole(role);
        }

        [HttpPut("UpdateRole")]
        public bool UpdateRole(Role role)
        {
            return _roleServices.UpdateRole(role);
        }

        [HttpDelete("DeleteRole/{id}")]
        public bool DeleteRole(int id)
        {
            return _roleServices.DeleteRole(id);
        }
    }
}
