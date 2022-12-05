using Dapper;
using Newspaper.Core.Common;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Newspaper.Infra.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Role> GetAllRole()
        {
            IEnumerable<Role> result = _dbContext.Connection.Query<Role>("Role_package.GetAllRole", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Role> result = _dbContext.Connection.Query<Role>("Role_package.GetRoleById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public bool CreateNewRole(Role role)
        {
            var p = new DynamicParameters();

            p.Add("p_RoleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
        

            var result = _dbContext.Connection.Execute("Role_package.CreateNewRole", p, commandType: CommandType.StoredProcedure);
            //result-->number of row effective
            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", role.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_RoleName", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
          

            var result = _dbContext.Connection.Execute("Role_package.UpdateRole", p, commandType: CommandType.StoredProcedure);
            //result-->number of row effective
            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Role_package.DeleteRole", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }



    }
}
