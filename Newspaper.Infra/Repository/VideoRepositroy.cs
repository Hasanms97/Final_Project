using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newspaper.Core.Common;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;

namespace Newspaper.Infra.Repository
{
	public class VideoRepositroy : IVideoRepository
	{
        private readonly IDbContext _dbContext;

        public VideoRepositroy(IDbContext _dbContext)
		{
            this._dbContext = _dbContext;
		}

        public bool CreateNewVideo(Video video)
        {
            var p = new DynamicParameters();

            p.Add("p_PAGEID", video.Pageid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_VIDEOPATH", video.Videopath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("VIDEO_PACKAGE.CreateNewVideo", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteVideo(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("VIDEO_PACKAGE.DeleteVideo", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Video> GetAllVideo()
        {
            IEnumerable<Video> result = _dbContext.Connection.Query<Video>("VIDEO_PACKAGE.GetAllVideo", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Video GetVideoById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Video> result = _dbContext.Connection.Query<Video>("VIDEO_PACKAGE.GetVideoById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Video> GetViedosByPageId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_PageID", id, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Video> result = _dbContext.Connection.Query<Video>("VIDEO_PACKAGE.GetViedosByPageId", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateVideo(Video video)
        {
            var p = new DynamicParameters();

            p.Add("p_PAGEID", video.Pageid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_VIDEOPATH", video.Videopath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("VIDEO_PACKAGE.UpdateVideo", p, commandType: CommandType.StoredProcedure);
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

