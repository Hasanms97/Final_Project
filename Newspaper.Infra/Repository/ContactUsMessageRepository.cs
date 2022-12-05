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
	public class ContactUsMessageRepository : IContactUsMessageRepository
	{
        private readonly IDbContext _dbContext;

        public ContactUsMessageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateNewOurWebsite(Contactusmessage contactusmessage)
        {
            var p = new DynamicParameters();

            p.Add("p_MESSAGE", contactusmessage.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PHONE", contactusmessage.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_RESPONDADMIN", contactusmessage.Respondadmin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_SUBJECT", contactusmessage.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_WEBSITEID", contactusmessage.Websiteid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_EMAIL", contactusmessage.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_NAME", contactusmessage.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CONTACTUSMESSAGE_PACKAGE.CreateNewContactUsMessage", p, commandType: CommandType.StoredProcedure);
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
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CONTACTUSMESSAGE_PACKAGE.DeleteContactUsMessage", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Contactusmessage> GetAllOurWebsite()
        {
            IEnumerable<Contactusmessage> result = _dbContext.Connection.Query<Contactusmessage>("CONTACTUSMESSAGE_PACKAGE.GetAllContactUsMessage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Contactusmessage GetOurWebsiteById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Contactusmessage> result = _dbContext.Connection.Query<Contactusmessage>("CONTACTUSMESSAGE_PACKAGE.GetContactUsMessagetById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool UpdateOurWebsite(Contactusmessage contactusmessage)
        {
            var p = new DynamicParameters();

            p.Add("p_MESSAGE", contactusmessage.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PHONE", contactusmessage.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_RESPONDADMIN", contactusmessage.Respondadmin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_SUBJECT", contactusmessage.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_WEBSITEID", contactusmessage.Websiteid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_EMAIL", contactusmessage.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_NAME", contactusmessage.Name, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CONTACTUSMESSAGE_PACKAGE.UpdateContactUsMessage", p, commandType: CommandType.StoredProcedure);
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

