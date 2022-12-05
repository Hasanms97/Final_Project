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
    public class NewsVideoRepository :INewsVideoRepository
    {
        private readonly IDbContext _dbContext;

        public NewsVideoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateNewNewsVideo(Newsvideo video)
        {
            var p = new DynamicParameters();

            p.Add("p_NEWSID", video.Newsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_VIDEOPATH", video.Videopath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("NEWSVIDEOS_tapi.InsertVideo", p, commandType: CommandType.StoredProcedure);
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
        public bool UpdateNewsVideo(Newsvideo video)
        {

            var p = new DynamicParameters();

            p.Add("p_VIDEOPATH", video.Videopath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ID", video.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
           

            var result = _dbContext.Connection.Execute("NEWSVIDEOS_tapi.UpdateVideo", p, commandType: CommandType.StoredProcedure);
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
        public bool DeleteNewsVideo(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("NEWSVIDEOS_tapi.DeleteVideo", p, commandType: CommandType.StoredProcedure);
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

        public  List<Newsvideo> GetAllNewsVideoByNewsId(int newsId)
        {
            var p = new DynamicParameters();
            p.Add("p_NEWSID", newsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Newsvideo> result = _dbContext.Connection.Query<Newsvideo>("NEWSVIDEOS_tapi.GetAllNewsVideos", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Newsvideo> GetAllVideo()
        {
            IEnumerable<Newsvideo> result = _dbContext.Connection.Query<Newsvideo>("NEWSVIDEOS_tapi.GetAllVideos", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }
}

