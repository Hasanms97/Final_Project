using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly ILoginRepository _loginRepository;

        public LoginServices(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public List<Login> GetAllLogin() { return _loginRepository.GetAllLogin(); }
        public Login GetLoginById(int id) {return _loginRepository.GetLoginById(id); }
        public bool CreateNewLogin(Login login) { return _loginRepository.CreateNewLogin(login); }
        public bool UpdateLogin(Login login) { return _loginRepository.UpdateLogin(login) ;}
        public bool DeleteLogin(int id) { return _loginRepository.DeleteLogin(id); }
        public int GetNumberOfUsersByRoleId(int id) { return _loginRepository.GetNumberOfUsersByRoleId(id); }
        public Task<List<User>> GetAllUsersByRoleId(int id) { return _loginRepository.GetAllUsersByRoleId(id); }
        public Login GetLoginByUserID(int id) { return _loginRepository.GetLoginByUserID(id); }
    }
}
