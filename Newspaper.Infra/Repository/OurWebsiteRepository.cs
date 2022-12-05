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
    public class OurWebsiteRepository : IOurWebsiteRepository
    {
        private readonly IDbContext _dbContext;

        public OurWebsiteRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Ourwebsite> GetAllOurWebsite()
        {
            IEnumerable<Ourwebsite> result = _dbContext.Connection.Query<Ourwebsite>("OurWebsite_package.GetAllOurWebsite", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ourwebsite GetOurWebsiteId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Ourwebsite> result = _dbContext.Connection.Query<Ourwebsite>("OurWebsite_package.GetOurWebsiteById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public bool CreateNewOurWebsite(Ourwebsite ourwebsite)
        {
            var p = new DynamicParameters();

            p.Add("p_PHONENUMBER", ourwebsite.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LINKLINKEDIN", ourwebsite.Linklinkedin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LINKFACEBOOK", ourwebsite.Linkfacebook, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LINKINSTAGRAM", ourwebsite.Linkinstagram, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_COSTHOSTANDDOMAINPERYEAR", ourwebsite.Costhostanddomainperyear, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_LINKTWITTER", ourwebsite.Linktwitter, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_COUNTRY", ourwebsite.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_MAPPATH", ourwebsite.Mappath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_COPYRIGHT", ourwebsite.Copyright, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_FAX", ourwebsite.Fax, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LOGOPATH", ourwebsite.Logopath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_WEBSITENAME", ourwebsite.Websitename, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("OurWebsite_package.CreateNewOurWebsite", p, commandType: CommandType.StoredProcedure);
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



        public bool UpdateNewOurWebsite(Ourwebsite ourwebsite)
        {
            var p = new DynamicParameters();

            p.Add("p_PHONENUMBER", ourwebsite.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LINKLINKEDIN", ourwebsite.Linklinkedin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LINKFACEBOOK", ourwebsite.Linkfacebook, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LINKINSTAGRAM", ourwebsite.Linkinstagram, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_COSTHOSTANDDOMAINPERYEAR", ourwebsite.Costhostanddomainperyear, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_LINKTWITTER", ourwebsite.Linktwitter, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_COUNTRY", ourwebsite.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_MAPPATH", ourwebsite.Mappath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_COPYRIGHT", ourwebsite.Copyright, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ID", ourwebsite.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_FAX", ourwebsite.Fax, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LOGOPATH", ourwebsite.Logopath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_WEBSITENAME", ourwebsite.Websitename, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("OurWebsite_package.UpdateOurWebsite", p, commandType: CommandType.StoredProcedure);
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


        public bool DeleteOurWebsite(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("OurWebsite_package.DeleteOurWebsite", p, commandType: CommandType.StoredProcedure);


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
