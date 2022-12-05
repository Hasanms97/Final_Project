using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.Core.Data;
using Newspaper.Core.Services;

namespace Newspaper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthJWTController : ControllerBase
    {
        private readonly IAuthJWTServices _authJWTServices;

        public AuthJWTController(IAuthJWTServices authJWTServices)
        {
            _authJWTServices = authJWTServices;
        }

        [HttpPost("AuthLogin")]
        public IActionResult AuthLogin(Login login)
        {
            var tokenLogin = _authJWTServices.AuthLogin(login); 

            if(tokenLogin == null)
            {
                return Unauthorized(); //401
                
            }
            else
            {
                return Ok(tokenLogin); //200
            }
        }
    }
}
