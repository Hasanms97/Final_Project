using Dapper;
using Newspaper.Core.Common;
using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Repository
{
    public class FavoriteNewsRepository : IFavoriteNewsRepository
    {
        private readonly IDbContext _dbContext;

        public FavoriteNewsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Favoritenews> GetAllFavoriteNews()
        {
            
            IEnumerable<Favoritenews> result = _dbContext.Connection.Query<Favoritenews>("FavoriteNews_package.GetAllFavoriteNews", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Favoritenews GetFavoriteNewsById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Favoritenews> result = _dbContext.Connection.Query<Favoritenews>("FavoriteNews_package.GetFavoriteNewsById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public bool CreateNewFavoriteNews(Favoritenews favoritenews)
        {
            var p = new DynamicParameters();

            p.Add("p_UserID", favoritenews.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CategoryID", favoritenews.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("FavoriteNews_package.CreateNewFavoriteNews", p, commandType: CommandType.StoredProcedure);
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
        public bool UpdateFavoriteNews(Favoritenews favoritenews)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", favoritenews.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_UserID", favoritenews.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CategoryID", favoritenews.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("FavoriteNews_package.UpdateFavoriteNews", p, commandType: CommandType.StoredProcedure);
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
        public bool DeleteFavoriteNews(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("FavoriteNews_package.DeleteFavoriteNews", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        public async Task<List<Category>> DisplayFavoriteNewsForUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            
            var result = await _dbContext.Connection.QueryAsync<Category, News, Category>("FavoriteNews_package.DisplayFavoriteNewsForUserId",
            (Category, news) =>
            {
                Category. News.Add(news);
                return Category;

            },p,
            splitOn: "Id",
            commandType: CommandType.StoredProcedure
            );

            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.News = g.Select(p => p.News.Single()).ToList();
                return groupedPost;
            });

            return results.ToList();
        }

        
        }
}
