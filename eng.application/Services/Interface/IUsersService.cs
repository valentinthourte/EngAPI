using eng.application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eng.application.Services.Interface
{
    public interface IUsersService
    {
        Task<bool> CreateUser(User user);
        Task<bool> DeleteById(Guid userId);
        Task<IEnumerable<User>> GetUsers();
        Task<User> UpdateUserStatus(Guid id, bool newStatus);
    }
}
