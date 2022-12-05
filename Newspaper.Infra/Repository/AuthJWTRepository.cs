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
    public class AuthJWTRepository : IAuthJWTRepository
    {
        private readonly IDbContext _dbContext;

        public AuthJWTRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Login AuthLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("p_Email", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("Login_package.CheckLoginUser", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
    }
}
