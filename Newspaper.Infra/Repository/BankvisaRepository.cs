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
    public class BankvisaRepository : IBankvisaRepository
    {
        private readonly IDbContext _dbContext;

        public BankvisaRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Bankvisa CheckBankVISA(Bankvisa bankvisa)
        {
            var p = new DynamicParameters();
            p.Add("p_cardNumber", bankvisa.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_cardHolderName", bankvisa.Cardholdername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CVV", bankvisa.Cvv, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ExpirationDate", bankvisa.Expirationdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            IEnumerable<Bankvisa> result = _dbContext.Connection.Query<Bankvisa>("BankVISA_package.checkBankVISA", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
