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
	public class PageRepository : IPageRepository
	{
        private readonly IDbContext _dbContext;

        public PageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateNewPage(Page page)
        {
            var p = new DynamicParameters();

            p.Add("p_PAGENAME", page.Pagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_WEBSITEID", page.Websiteid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("PAGE_PACKAGE.CreateNewPage", p, commandType: CommandType.StoredProcedure);
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

        public bool DeletePage(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("PAGE_PACKAGE.DeletePage", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Page> GetAllPage()
        {
            IEnumerable<Page> result = _dbContext.Connection.Query<Page>("PAGE_PACKAGE.GetAllPage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Page GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Page> result = _dbContext.Connection.Query<Page>("PAGE_PACKAGE.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool UpdatePage(Page page)
        {
            var p = new DynamicParameters();

            p.Add("p_PAGENAME", page.Pagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_WEBSITEID", page.Websiteid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("PAGE_PACKAGE.UpdatePage", p, commandType: CommandType.StoredProcedure);
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

