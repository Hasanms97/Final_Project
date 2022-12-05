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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Category> GetAllCategory()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("Category_package.GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Category GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Category> result = _dbContext.Connection.Query<Category>("Category_package.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool CreateNewCategory(Category category)
        {
            var p = new DynamicParameters();

            p.Add("p_Name", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ImagePath", category.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Description", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Category_package.CreateNewCategory", p, commandType: CommandType.StoredProcedure);
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
        public bool UpdateCategory(Category category)
        {
            var p = new DynamicParameters();

            p.Add("p_Id", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Name", category.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ImagePath", category.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Description", category.Description, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Category_package.UpdateCategory", p, commandType: CommandType.StoredProcedure);
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
        public bool DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Category_package.DeleteCategory", p, commandType: CommandType.StoredProcedure);


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
