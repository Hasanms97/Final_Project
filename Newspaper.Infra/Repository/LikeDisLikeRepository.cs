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
    public class LikeDisLikeRepository :ILikeDisLikeRepository
    {
        private readonly IDbContext _dbContext;

        public LikeDisLikeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateNewLikeDisLike(LikeDislike like)
        {
            var p = new DynamicParameters();

            p.Add("p_NEWSID", like.Newsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_DATE_LIKEDISLIKE", like.DateLikedislike, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_USERID", like.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TYPE", like.Type, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("LIKE_DISLIKE_tapi.insert_Like_Dislike", p, commandType: CommandType.StoredProcedure);
   
            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateLikeDisLike(LikeDislike like)
        {
            var p = new DynamicParameters(); 
            p.Add("p_ID", like.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_NEWSID", like.Newsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_DATE_LIKEDISLIKE", like.DateLikedislike, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_USERID", like.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TYPE", like.Type, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("LIKE_DISLIKE_tapi.Update_Like_Dislike", p, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool DeleteLikeDisLike(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("LIKE_DISLIKE_tapi.Delete_Like_Dislike", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        public int GetNumberOfLike(int newsId)
        {
            var p = new DynamicParameters();
            p.Add("p_NEWSID", newsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            int result = _dbContext.Connection.ExecuteScalar<int>("LIKE_DISLIKE_tapi.GetNumberOfLike", p, commandType: CommandType.StoredProcedure);
            return result;

        }
        public int GetNumberOfDisLike(int newsId)
        {
            var p = new DynamicParameters();
            p.Add("p_NEWSID", newsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            int result = _dbContext.Connection.ExecuteScalar<int>("LIKE_DISLIKE_tapi.GetNumberOfDisLike", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public LikeDislike GetLikeById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<LikeDislike> result = _dbContext.Connection.Query<LikeDislike>("LIKE_DISLIKE_tapi.GetLikeById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
        public string CheckUserLikeOrDisLike(int newsId, int userId)
        {
            var p = new DynamicParameters();
            p.Add("p_NEWSID", newsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_USERID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            string result = _dbContext.Connection.ExecuteScalar<string>("LIKE_DISLIKE_tapi.CheckUserLike_DisLike", p, commandType: CommandType.StoredProcedure);
            return result;

        }
        public List<LikeDislike> GetAllUserLikeDislike(int userId)
        {
            var p = new DynamicParameters();
            p.Add("p_USERID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<LikeDislike> result = _dbContext.Connection.Query<LikeDislike>("LIKE_DISLIKE_tapi.GetAllUserLikes", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
