using Newspaper.Core.Data;
using Newspaper.Core.Repository;
using Newspaper.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newspaper.Infra.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUsersRepository _usersRepository;

        public UserServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<User> GetAllUser() { return _usersRepository.GetAllUser(); }
        public User GetUserById(int id) { return _usersRepository.GetUserById(id); }
        public bool CreateNewUser(User Use) { return _usersRepository.CreateNewUser(Use); }
        public bool UpdateUser(User Use) { return _usersRepository.UpdateUser(Use); }
        public bool DeleteUser(int id) { return _usersRepository.DeleteUser(id); }

        public List<EmailNotificationsDTO> GetAllUsersByEmailNotifications() { return _usersRepository.GetAllUsersByEmailNotifications(); }
        public Task<List<User>> GetAllRequestsAccountPressman() { return _usersRepository.GetAllRequestsAccountPressman(); }
        public bool ApproveRejectAccountPressman(User Use) { return _usersRepository.ApproveRejectAccountPressman(Use); }
    }
}
