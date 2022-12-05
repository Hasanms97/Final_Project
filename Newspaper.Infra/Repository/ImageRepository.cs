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
	public class ImageRepository : IImageRepository
	{
        private readonly IDbContext _dbContext;

        public ImageRepository(IDbContext _dbContext)
		{
            this._dbContext = _dbContext;
        }

        public bool CreateNewImage(Image image)
        {
            var p = new DynamicParameters();

            p.Add("p_PAGEID", image.Pageid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IMAGEPATH", image.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
           

            var result = _dbContext.Connection.Execute("IMAGE_PACKAGE.CreateNewImage", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteImage(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("IMAGE_PACKAGE.DeleteImage", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Image> GetAllImage()
        {
            IEnumerable<Image> result = _dbContext.Connection.Query<Image>("IMAGE_PACKAGE.GetAllImage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Image GetImageById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Image> result = _dbContext.Connection.Query<Image>("IMAGE_PACKAGE.GetImageById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Image> GetImagesByPageId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Image> result = _dbContext.Connection.Query<Image>("IMAGE_PACKAGE.GetAllImage", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateImage(Image image)
        {
            var p = new DynamicParameters();

            p.Add("p_PAGEID", image.Pageid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IMAGEPATH", image.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("IMAGE_PACKAGE.UpdateImage", p, commandType: CommandType.StoredProcedure);
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

