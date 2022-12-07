using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Newspaper.Core.Common;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;

namespace Newspaper.Infra.Repository
{
	public class ContentRepository : IContentRepository
	{

        private readonly IDbContext _dbContext;

		public ContentRepository(IDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public bool CreateNewContent(Content Content)
        {
            var p = new DynamicParameters();

            p.Add("p_PAGEID", Content.Pageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TEXT", Content.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            
            

            var result = _dbContext.Connection.Execute("CONTENT_PACKAGE.CreateNewContent", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteContent(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CONTENT_PACKAGE.DeleteContent", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Content> GetAllContent()
        {
            IEnumerable<Content> result = _dbContext.Connection.Query<Content>("CONTENT_PACKAGE.GetAllContent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Content GetContentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Content> result = _dbContext.Connection.Query<Content>("CONTENT_PACKAGE.GetContentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        //CHNAGE
        public List<Content> GetContentByPageId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Content> result = _dbContext.Connection.Query<Content>("CONTENT_PACKAGE.GetContentById", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateContent(Content Content)
        {
            var p = new DynamicParameters();

            p.Add("p_PAGEID", Content.Pageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_TEXT", Content.Text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ID", Content.Pageid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CONTENT_PACKAGE.UpdateContent", p, commandType: CommandType.StoredProcedure);
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

