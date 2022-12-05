using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class AuthJWTServices : IAuthJWTServices
    {
        private readonly IAuthJWTRepository _authJWTRepository;
        private readonly IConfiguration _configuration;

        public AuthJWTServices(IAuthJWTRepository authJWTRepository, IConfiguration configuration)
        {
            _authJWTRepository = authJWTRepository;
            _configuration = configuration;
        }

        public string AuthLogin(Login login)
        {
            // Call AuthLogin(login) from AuthJWTRepository
            var resultLogin = _authJWTRepository.AuthLogin(login);
            if (resultLogin == null)
            {
                return null;
            }
            else
            {
                //key انشاء ال
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<String>("JWT:KeyJWT")));
                //algorithm تحديد ال
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                //تخزين البيانات
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, resultLogin.Email),
                        new Claim(ClaimTypes.NameIdentifier , resultLogin.Userid.ToString()),
                        new Claim(ClaimTypes.Role, resultLogin.Roleid.ToString())
                        
                    };
                //Options تحديد ال
                var tokeOptions = new JwtSecurityToken(
                   claims: claims,
                   expires: DateTime.Now.AddMinutes(60),
                   signingCredentials: signinCredentials
                );
                //Token انشاء ال
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return tokenString;


            }
        }
    }
}
