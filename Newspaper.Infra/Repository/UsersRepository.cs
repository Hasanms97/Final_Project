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
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContext _dbContext;

        public UsersRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAllUser()
        {
            IEnumerable<User> result = _dbContext.Connection.Query<User>("Users_package.GetAllUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public User GetUserById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<User> result = _dbContext.Connection.Query<User>("Users_package.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool CreateNewUser(User Use)
        {
            var p = new DynamicParameters();

            p.Add("p_FirstName", Use.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LastName", Use.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Gender", Use.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DateofBirth", Use.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Country", Use.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PhoneNumber", Use.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ImagePath", Use.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_JournalistCertificatePath", Use.Journalistcertificatepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Description", Use.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Salary", Use.Salary, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_Owner", Use.Owner, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CheckAdmin", Use.Checkadmin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_EmailNotifications", Use.Emailnotifications, dbType: DbType.String, direction: ParameterDirection.Input);
            

            var result = _dbContext.Connection.Execute("Users_package.CreateNewUser", p, commandType: CommandType.StoredProcedure);
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

        public bool UpdateUser(User Use)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", Use.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_FirstName", Use.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_LastName", Use.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Gender", Use.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_DateofBirth", Use.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_Country", Use.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_PhoneNumber", Use.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ImagePath", Use.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_JournalistCertificatePath", Use.Journalistcertificatepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Description", Use.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Salary", Use.Salary, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_Owner", Use.Owner, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CheckAdmin", Use.Checkadmin, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_EmailNotifications", Use.Emailnotifications, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Users_package.UpdateUser", p, commandType: CommandType.StoredProcedure);
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

        public bool DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Users_package.DeleteUser", p, commandType: CommandType.StoredProcedure);


            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<EmailNotificationsDTO> GetAllUsersByEmailNotifications()
        {
            IEnumerable<EmailNotificationsDTO> result = _dbContext.Connection.Query<EmailNotificationsDTO>("Users_package.GetAllUsersByEmailNotifications", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<User>> GetAllRequestsAccountPressman()
        {
            var result = await _dbContext.Connection.QueryAsync<User, Login, User>("Users_package.GetAllRequestsAccountPressman",
            (User, login) =>
            {
                User.Logins.Add(login);
                return User;
            }, splitOn: "Id",
            param: null,
            commandType: CommandType.StoredProcedure
            );
            
            return result.ToList();
        }

        public bool ApproveRejectAccountPressman(User Use)
        {
            var p = new DynamicParameters();
            p.Add("p_Id", Use.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CheckAdmin", Use.Checkadmin, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Users_package.ApproveRejectAccountPressman", p, commandType: CommandType.StoredProcedure);


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
