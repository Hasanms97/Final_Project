using Newspaper.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Core.Services
{
    public interface IUserServices
    {
        List<User> GetAllUser();
        User GetUserById(int id);
        bool CreateNewUser(User Use);
        bool UpdateUser(User Use);
        bool DeleteUser(int id);

        List<EmailNotificationsDTO> GetAllUsersByEmailNotifications();
        Task<List<User>> GetAllRequestsAccountPressman();
        bool ApproveRejectAccountPressman(User Use);
    }
}
