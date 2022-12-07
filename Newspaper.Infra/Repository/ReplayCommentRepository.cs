using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using Newspaper.Core.Common;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using System.Linq;

namespace Newspaper.Infra.Repository
{
	public class ReplayCommentRepository : IReplayCommentRepository
	{
        private readonly IDbContext _dbContext;

        public ReplayCommentRepository(IDbContext _dbContext)
		{
            this._dbContext = _dbContext;
		}

        public bool CreateNewReplayComment(Replycommentt replycommentt)
        {
            var p = new DynamicParameters();

            p.Add("p_DATE_REPLYCOMMENT", replycommentt.DateReplycomment, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_COMMENTTID", replycommentt.Commenttid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_USERID", replycommentt.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TEXT", replycommentt.Text, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("REPLYCOMMENTT_PACKAGE.CreateNewReplayComment", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteReplayComment(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("REPLYCOMMENTT_PACKAGE.DeleteReplayComment", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Replycommentt> GetAllReplayComment()
        {
            IEnumerable<Replycommentt> result = _dbContext.Connection.Query<Replycommentt>("REPLYCOMMENTT_PACKAGE.GetAllReplayComment", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Replycommentt> GetAllReplayCommentOnComment(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Replycommentt> result = _dbContext.Connection.Query<Replycommentt>("REPLYCOMMENTT_PACKAGE.GetAllReplayCommentOnComment",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Replycommentt GetReplayCommentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Replycommentt> result = _dbContext.Connection.Query<Replycommentt>("REPLYCOMMENTT_PACKAGE.GetReplayCommentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool UpdateReplayComment(Replycommentt replycommentt)
        {
            var p = new DynamicParameters();

            p.Add("p_DATE_REPLYCOMMENT", replycommentt.DateReplycomment, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_COMMENTTID", replycommentt.Commenttid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_USERID", replycommentt.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TEXT", replycommentt.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ID", replycommentt.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("REPLYCOMMENTT_PACKAGE.UpdateReplayComment", p, commandType: CommandType.StoredProcedure);
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

