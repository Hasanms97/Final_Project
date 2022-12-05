using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newspaper.Infra.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _roleRepository;

        public RoleServices(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Role> GetAllRole() { return _roleRepository.GetAllRole(); }
        public Role GetRoleById(int id) { return _roleRepository.GetRoleById(id); }
        public bool CreateNewRole(Role role) { return _roleRepository.CreateNewRole(role); }
        public bool UpdateRole(Role role) { return _roleRepository.UpdateRole(role); }
        public bool DeleteRole(int id) { return _roleRepository.DeleteRole(id); }
    }
}
