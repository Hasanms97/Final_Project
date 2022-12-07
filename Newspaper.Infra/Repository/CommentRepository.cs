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
    public class CommentRepository: ICommentRepository
    {
        private readonly IDbContext _dbContext;

        public CommentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateNewComment(Commentt comment)
        {
            var p = new DynamicParameters();
            p.Add("p_NEWSID", comment.Newsid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DATE_COMMENT", comment.DateComment, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_USERID", comment.Userid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TEXT", comment.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            
            var result = _dbContext.Connection.Execute("COMMENTT_tapi.Insert_Comment", p, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public bool UpdateComment(Commentt comment)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", comment.Id, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("p_NEWSID", comment.Newsid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DATE_COMMENT", comment.DateComment, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_USERID", comment.Userid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TEXT", comment.Text, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("COMMENTT_tapi.Update_Comment", p, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool DeleteComment(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("COMMENTT_tapi.Delete_Comment", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        public int GetAllNumberOfComments(int newsId)
        {

            var p = new DynamicParameters();
            p.Add("p_NEWSID", newsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            int result = _dbContext.Connection.ExecuteScalar<int>("COMMENTT_tapi.GetAllNumberOfComments", p, commandType: CommandType.StoredProcedure);
            return result;


        }
        public News GetCommentById(int id)
        {

            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<News> result = _dbContext.Connection.Query<News>("COMMENTT_tapi.GetCommentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public async Task<List<Commentt>> GetAllNewsComments(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_NEWSID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Commentt, Replycommentt, Commentt>("COMMENTT_tapi.GetAllNewsComments",
            (Commentt,replycommentt) =>
            {

                Commentt.Replycommentts.Add(replycommentt);
                return Commentt;


            },p, splitOn: "Id",
            commandType: CommandType.StoredProcedure
            );


            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Replycommentts = g.Select(p => p.Replycommentts.Single()).ToList();
                return groupedPost;
            });


            return results.ToList();

        }
        public List<Commentt> GetAllUsersComments(int userId)
        {
            var p = new DynamicParameters();
            p.Add("p_USERID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Commentt> result = _dbContext.Connection.Query<Commentt>("COMMENTT_tapi.GetAllUsersComments",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
