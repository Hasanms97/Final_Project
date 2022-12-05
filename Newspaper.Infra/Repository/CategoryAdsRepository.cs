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
    public class CategoryAdsRepository : ICategoryAdsRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryAdsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Categoryad> GetAllCategoryAds()
        {
            IEnumerable<Categoryad> result = _dbContext.Connection.Query<Categoryad>("CategoryAds_package.GetAllCategoryAds", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Categoryad GetCategoryAdsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Categoryad> result = _dbContext.Connection.Query<Categoryad>("CategoryAds_package.GetCategoryAdsById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool CreateNewCategoryAds(Categoryad categoryad)
        {
            var p = new DynamicParameters();

            p.Add("p_Type", categoryad.Type, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DurationInMonth", categoryad.Durationinmonth, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Price", categoryad.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CategoryAds_package.CreateNewCategoryAds", p, commandType: CommandType.StoredProcedure);
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
        public bool UpdateCategoryAds(Categoryad categoryad)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", categoryad.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Type", categoryad.Type, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DurationInMonth", categoryad.Durationinmonth, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Price", categoryad.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CategoryAds_package.UpdateCategoryAds", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteCategoryAds(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CategoryAds_package.DeleteCategoryAds", p, commandType: CommandType.StoredProcedure);


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
