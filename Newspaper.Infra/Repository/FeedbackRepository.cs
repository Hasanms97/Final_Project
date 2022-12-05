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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IDbContext _dbContext;

        public FeedbackRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Feedback> GetAllFeedback()
        {
            IEnumerable<Feedback> result = _dbContext.Connection.Query<Feedback>("Feedback_package.GetAllFeedback", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Feedback GetFeedbackById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Feedback> result = _dbContext.Connection.Query<Feedback>("Feedback_package.GetFeedbackById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool CreateNewFeedback(Feedback feedback)
        {
            var p = new DynamicParameters();

            p.Add("p_Description", feedback.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Evaluation", feedback.Evaluation, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CheckAdmin", feedback.Checkadmin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_UserID", feedback.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Feedback_package.CreateNewFeedback", p, commandType: CommandType.StoredProcedure);
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

        public bool UpdateFeedback(Feedback feedback)
        {
            var p = new DynamicParameters();

            p.Add("p_Id", feedback.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Description", feedback.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Evaluation", feedback.Evaluation, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CheckAdmin", feedback.Checkadmin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_UserID", feedback.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Feedback_package.UpdateFeedback", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteFeedback(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Feedback_package.DeleteFeedback", p, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<Feedback> GetAllFeedbackUnderStudyOfAdmin()
        {
            IEnumerable<Feedback> result = _dbContext.Connection.Query<Feedback>("Feedback_package.GetAllFeedbackUnderStudyOfAdmin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool ApproveRejectFeedback(Feedback feedback)
        {
            var p = new DynamicParameters();

            p.Add("p_Id", feedback.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CheckAdmin", feedback.Checkadmin, dbType: DbType.String, direction: ParameterDirection.Input);
           
            var result = _dbContext.Connection.Execute("Feedback_package.ApproveRejectFeedback", p, commandType: CommandType.StoredProcedure);
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
