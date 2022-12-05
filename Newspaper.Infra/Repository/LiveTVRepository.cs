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
    public class LiveTVRepository : ILiveTVRepository
    {
        private readonly IDbContext _dbContext;

        public LiveTVRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Livetv> GetAllLiveTV()
        {
            IEnumerable<Livetv> result = _dbContext.Connection.Query<Livetv>("LiveTV_Package.GetAllLiveTV", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Livetv GetLiveTVById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Livetv> result = _dbContext.Connection.Query<Livetv>("LiveTV_Package.GetLiveTVById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public bool CreateNewLiveTV(Livetv livetv)
        {
            var p = new DynamicParameters();

            p.Add("p_LINK", livetv.Link, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TVNAME", livetv.Tvname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IMAGEPATH", livetv.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("LiveTV_Package.CreateNewLiveTV", p, commandType: CommandType.StoredProcedure);
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

        public bool UpdateLiveTV(Livetv livetv)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", livetv.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_LINK", livetv.Link, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_TVNAME", livetv.Tvname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IMAGEPATH", livetv.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("LiveTV_Package.UpdateLiveTV", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteLiveTV(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("LiveTV_Package.DeleteLiveTV", p, commandType: CommandType.StoredProcedure);


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
