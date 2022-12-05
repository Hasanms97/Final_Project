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
    public class NewsRepository : INewsRepository
    {
        private readonly IDbContext _dbContext;

        public NewsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public bool CreateNewNews(News news)
        {
            var p = new DynamicParameters();
            p.Add("p_NEWSDATE", news.Newsdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_COUNTRY", news.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DESCRIPTION", news.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_NEWSTITLE", news.Newstitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CATEGORYID", news.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_USERID_PRESSMAN", news.UseridPressman, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CHECKADMIN", news.Checkadmin, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("NEWS_tapi.ins", p, commandType: CommandType.StoredProcedure);
         
            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdateNews(News news)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", news.Id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_NEWSDATE", news.Newsdate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_COUNTRY", news.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DESCRIPTION", news.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_NEWSTITLE", news.Newstitle, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CATEGORYID", news.Categoryid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_USERID_PRESSMAN", news.UseridPressman, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CHECKADMIN", news.Checkadmin, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("NEWS_tapi.upd", p, commandType: CommandType.StoredProcedure);

            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool DeleteNews(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("NEWS_tapi.del", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<News> GetAllInProgressNew()
        {
            IEnumerable<News> result = _dbContext.Connection.Query<News>("NEWS_tapi.GetAllInProgressNew", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public List<News> GetAllNews()
        {
            IEnumerable<News> result = _dbContext.Connection.Query<News>("NEWS_tapi.GetAllNews", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public News GetNewsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("News_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<News> result = _dbContext.Connection.Query<News>("NEWS_tapi.GetNewsByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool ApprovOrRejectNews(int id, string AdminCheck)
        {
            var p = new DynamicParameters();
            p.Add("News_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CHECKADMIN", AdminCheck, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("NEWS_tapi.ApprovOrRejectNews", p, commandType: CommandType.StoredProcedure);

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
