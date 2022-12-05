using Dapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly IDbContext _dbContext;

        public AdvertisementRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllAdvertisement()
        {

            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAllAdvertisement",
            (User, advertisement, login) =>
            {
                
                    User.Advertisements.Add(advertisement);
                    User.Logins.Add(login);
                    return User;
                

            }, splitOn: "Id",
            param: null,
            commandType: CommandType.StoredProcedure
            );
            

            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });


            return results.ToList();
            
        }


        public async Task<List<User>> GetAdvertisementById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAdvertisementById",
            (User, advertisement, login) =>
            {

                User.Advertisements.Add(advertisement);
                User.Logins.Add(login);
                return User;

            },p,
            splitOn: "Id",
            commandType: CommandType.StoredProcedure
            );

            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });

            return results.ToList();

        }

        public async Task<List<User>> GetAdvertisementByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAdvertisementByUserId",
            (User, advertisement, login) =>
            {

                User.Advertisements.Add(advertisement);
                User.Logins.Add(login);
                return User;

            }, p,
            splitOn: "Id",
            commandType: CommandType.StoredProcedure
            );

            var results = result.GroupBy(p => p.Id).Select(g => 
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });

            return results.ToList();

        }

        

        public async Task<List<User>> GetAdvertisementByNeedToApproveTheAds()
        {

            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAdvertisementByNeedToApproveTheAds",
            (User, advertisement, login) =>
            {

                User.Advertisements.Add(advertisement);
                User.Logins.Add(login);
                return User;

            }, splitOn: "Id",
            param: null,
            commandType: CommandType.StoredProcedure
            );



            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });


            return results.ToList();

        }

        public async Task<List<User>> GetAdvertisementByNeedToApprovalToPay()
        {

            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAdvertisementByNeedToApprovalToPay",
            (User, advertisement, login) =>
            {

                User.Advertisements.Add(advertisement);
                User.Logins.Add(login);
                return User;

            }, splitOn: "Id",
            param: null,
            commandType: CommandType.StoredProcedure
            );



            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });


            return results.ToList();

        }

        public async Task<List<User>> GetAdvertisementEffectiveAds()
        {

            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAdvertisementEffectiveAds",
            (User, advertisement, login) =>
            {

                User.Advertisements.Add(advertisement);
                User.Logins.Add(login);
                return User;

            }, splitOn: "Id",
            param: null,
            commandType: CommandType.StoredProcedure
            );



            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });


            return results.ToList();

        }

        public async Task<List<User>> GetAdvertisementByYear(int year)
        {
            var p = new DynamicParameters();
            p.Add("p_Year", year, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAdvertisementByYear",
            (User, advertisement, login) =>
            {

                User.Advertisements.Add(advertisement);
                User.Logins.Add(login);
                return User;

            }, p,
            splitOn: "Id",
            commandType: CommandType.StoredProcedure
            );

            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });

            return results.ToList();

        }


        public async Task<List<User>> GetAdvertisementByMonth(DateTime date)
        {
            var p = new DynamicParameters();
            p.Add("p_date", date, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAdvertisementByMonth",
            (User, advertisement, login) =>
            {
                
                User.Advertisements.Add(advertisement);
                User.Logins.Add(login);
                return User;

            }, p,
            splitOn: "Id",
            commandType: CommandType.StoredProcedure
            );

            var results = result.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });

            return results.ToList();

        }
        public async Task<List<User>> GetAllAdvertisementBySearchBetweenTwoDates(SearchBetweenTwoDatesDTO searchBetweenTwoDatesDTO)
        {

            var result = await _dbContext.Connection.QueryAsync<User, Advertisement, Login, User>("Advertisement_PACKAGE.GetAllAdvertisement",
            (User, advertisement, login) =>
            {

                User.Advertisements.Add(advertisement);
                User.Logins.Add(login);
                return User;


            }, splitOn: "Id",
            param: null,
            commandType: CommandType.StoredProcedure
            );

            var resultSearchBetweenTwoDates  = new List<User>();
            if (searchBetweenTwoDatesDTO.Datefrom == null && searchBetweenTwoDatesDTO.Dateto == null)
            {
                 resultSearchBetweenTwoDates = result.Where(o => o.Advertisements.Any(i => i.Checkadminonads == "Yes"
                                                                                     && i.Checkadmintopay == "Yes")).ToList();
            }
            else if(searchBetweenTwoDatesDTO.Datefrom == null)
            {
                resultSearchBetweenTwoDates = result.Where(o => o.Advertisements.Any(i => i.Checkadminonads == "Yes"
                                                                                     && i.Checkadmintopay == "Yes"
                                                                                     && i.Datefrom.Value.Date <= searchBetweenTwoDatesDTO.Dateto.Value.Date)).ToList();

            }
            else if (searchBetweenTwoDatesDTO.Dateto == null)
            {
                resultSearchBetweenTwoDates = result.Where(o => o.Advertisements.Any(i => i.Checkadminonads == "Yes"
                                                                                     && i.Checkadmintopay == "Yes"
                                                                                     && i.Datefrom.Value.Date >= searchBetweenTwoDatesDTO.Datefrom.Value.Date)).ToList();

            }
            else
            {
                 resultSearchBetweenTwoDates = result.Where(o => o.Advertisements.Any(i => i.Checkadminonads == "Yes"
                                                                                         && i.Checkadmintopay == "Yes"
                                                                                         && (i.Datefrom.Value.Date >= searchBetweenTwoDatesDTO.Datefrom.Value.Date
                                                                                         && i.Datefrom.Value.Date <= searchBetweenTwoDatesDTO.Dateto.Value.Date))).ToList();
            }

            var results = resultSearchBetweenTwoDates.GroupBy(p => p.Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Advertisements = g.Select(p => p.Advertisements.Single()).ToList();
                return groupedPost;
            });


            return results.ToList();

        }

        public bool CreateNewAdvertisement(Advertisement advertisement)
        {
            var p = new DynamicParameters();

            p.Add("p_DATEFROM", advertisement.Datefrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_VIDEOPATH", advertisement.Videopath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_USERID", advertisement.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CATEGORYADSID", advertisement.Categoryadsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_LINK", advertisement.Link, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_IMAGEPATH", advertisement.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DATETO", advertisement.Dateto, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_CheckAdminOnAds", advertisement.Checkadminonads, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CheckAdminOnPay", advertisement.Checkadmintopay, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Advertisement_PACKAGE.CreateNewAdvertisement", p, commandType: CommandType.StoredProcedure);
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
        public bool UpdateAdvertisement(Advertisement advertisement)
        {
            var p = new DynamicParameters();

            p.Add("p_DATEFROM", advertisement.Datefrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_CHECKADMIN_TOPAY", advertisement.Checkadmintopay, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CHECKADMIN_ONADS", advertisement.Checkadminonads, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_VIDEOPATH", advertisement.Videopath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_USERID", advertisement.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CATEGORYADSID", advertisement.Categoryadsid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_LINK", advertisement.Link, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ID", advertisement.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_IMAGEPATH", advertisement.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DATETO", advertisement.Dateto, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Advertisement_PACKAGE.UpdateAdvertisement", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteAdvertisement(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Advertisement_PACKAGE.DeleteAdvertisement", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public bool ApprovalOrRejectionCheckAdminOnAds(Advertisement advertisement)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", advertisement.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CheckAdminOnAds", advertisement.Checkadminonads, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Advertisement_PACKAGE.ApprovalOrRejectionCheckAdminOnAds", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool ApprovalOrRejectionCheckAdminOnPay(Advertisement advertisement)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", advertisement.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CheckAdminOnPay", advertisement.Checkadmintopay, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Advertisement_PACKAGE.ApprovalOrRejectionCheckAdminOnPay", p, commandType: CommandType.StoredProcedure);


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
