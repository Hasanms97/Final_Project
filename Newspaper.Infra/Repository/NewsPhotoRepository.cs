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
    public class NewsPhotoRepository :INewsPhotoRepository
    {
        private readonly IDbContext _dbContext;

        public NewsPhotoRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateNewNewsPhoto(Newsphoto photo)
        {
            var p = new DynamicParameters();

            p.Add("p_NEWSID", photo.Newsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_IMAGEPATH", photo.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("NEWSPHOTOS_tapi.Insert_Photo", p, commandType: CommandType.StoredProcedure);
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
        public bool UpdateNewsPhoto(Newsphoto photo)
        {

            var p = new DynamicParameters();
            p.Add("p_ID", photo.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_IMAGEPATH", photo.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("NEWSPHOTOS_tapi.Update_photo", p, commandType: CommandType.StoredProcedure);
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
        public bool DeleteNewsPhoto(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("NEWSPHOTOS_tapi.delete_Photo", p, commandType: CommandType.StoredProcedure);
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

        public List<Newsphoto> GetAllNewsPhotoByNewsId(int newsId)
        {

            var p = new DynamicParameters();
            p.Add("p_NEWSID", newsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Newsphoto> result = _dbContext.Connection.Query<Newsphoto>("NEWSPHOTOS_tapi.GetAllNewsPhoto",p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public List<Newsphoto> GetAllPhoto()
        {
            IEnumerable<Newsphoto> result = _dbContext.Connection.Query<Newsphoto>("NEWSPHOTOS_tapi.GetAllPhoto", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
