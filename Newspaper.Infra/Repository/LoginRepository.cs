using Dapper;
using Newspaper.Core.Common;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _dbContext;

        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Login> GetAllLogin()
        {
            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("Login_package.GetAllLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Login GetLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("Login_package.GetLoginById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool CreateNewLogin(Login login)
        {
            var p = new DynamicParameters();

            p.Add("p_Email", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_UserID", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_RoleID", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Login_package.CreateNewLogin", p, commandType: CommandType.StoredProcedure);
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
        public bool UpdateLogin(Login login)
        {
            var p = new DynamicParameters();

            p.Add("p_Id", login.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Email", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_UserID", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_RoleID", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Login_package.UpdateLogin", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Login_package.DeleteLogin", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public int GetNumberOfUsersByRoleId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_RoleID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<int> result = _dbContext.Connection.Query<int>("Login_package.GetNumberOfUsersByRoleId", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<User>> GetAllUsersByRoleId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_RoleID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<User, Login, User>("Login_package.GetAllUsersByRoleId",
             (User, login) =>
            {
                User.Logins.Add(login);
                return User;
            }, p,
            splitOn: "Id",
            commandType: CommandType.StoredProcedure
            );

            //IEnumerable<User> result = _dbContext.Connection.Query<User>("Login_package.GetAllUsersByRoleId", p,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Login GetLoginByUserID(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("Login_package.GetLoginByUserID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}
