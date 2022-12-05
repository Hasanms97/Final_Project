using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using Newspaper.Core.Common;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using System.Linq;
using System.Collections.Specialized;

namespace Newspaper.Infra.Repository
{
	public class FollowRepository : IFollowRepository
	{
        private readonly IDbContext _dbContext;

        public FollowRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckFollowers(int p_UserID, int p_PressManID)
        {
            var p = new DynamicParameters();
            p.Add("p_PRESSMANID", p_PressManID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_USERID", p_UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var count = _dbContext.Connection.Query("FOLLOW_PACKAGE.CheckFollowers", p, commandType: CommandType.StoredProcedure);

            return (dynamic) count;
        }

        public bool CreateNewFollow(Follow follow)
        {
            var p = new DynamicParameters();

            p.Add("p_PRESSMANID", follow.Pressmanid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_USERID", follow.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            

            var result = _dbContext.Connection.Execute("FOLLOW_PACKAGE.CreateNewFollow", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteFollow(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("FOLLOW_PACKAGE.DeleteFollow", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<Follow> GetAllFollow()
        {
            IEnumerable<Follow> result = _dbContext.Connection.Query<Follow>("FOLLOW_PACKAGE.GetAllFollow", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Follow GetFollowById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Follow> result = _dbContext.Connection.Query<Follow>("FOLLOW_PACKAGE.GetFollowById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int GetNumberOfFollowers(int p_PressManID)
        {
            //CHECK IMPLEMENTATION

            var p = new DynamicParameters();

            p.Add("p_PressManID", p_PressManID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var count = _dbContext.Connection.Query("FOLLOW_PACKAGE.GetNumberOfFollowers", commandType: CommandType.StoredProcedure);

            return (dynamic) count;
        }

        public bool UpdateFollow(Follow follow)
        {
            var p = new DynamicParameters();

            p.Add("p_PRESSMANID", follow.Pressmanid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_USERID", follow.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("FOLLOW_PACKAGE.UpdateFollow", p, commandType: CommandType.StoredProcedure);
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
    }
}

