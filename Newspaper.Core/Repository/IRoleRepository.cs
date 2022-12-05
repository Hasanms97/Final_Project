using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Core.Repository
{
    public interface IRoleRepository
    {
        List<Role> GetAllRole();
        Role GetRoleById(int id);
        bool CreateNewRole(Role role);
        bool UpdateRole(Role role);
        bool DeleteRole(int id);
    }
}
