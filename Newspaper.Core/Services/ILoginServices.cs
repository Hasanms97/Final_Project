using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Core.Services
{
    public interface ILoginServices
    {
        List<Login> GetAllLogin();
        Login GetLoginById(int id);
        bool CreateNewLogin(Login login);
        bool UpdateLogin(Login login);
        bool DeleteLogin(int id);
        int GetNumberOfUsersByRoleId(int id);
        Task<List<User>> GetAllUsersByRoleId(int id);
        Login GetLoginByUserID(int id);
    }
}
