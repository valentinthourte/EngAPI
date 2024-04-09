using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eng.application.Model;
using eng.application.Services.Interface;
using eng.repository.Interface;

namespace eng.application.Services
{
    public class UsersService : IUsersService
    {
        private IUsersRepository UsersRepository;
        public UsersService(IUsersRepository usersRepository) 
        {
            UsersRepository = usersRepository;
        }

        public async Task<bool> CreateUser(User user)
        {
            User createdUser = await UsersRepository.CreateUser(user);
            return true;
        }

        public async Task<bool> DeleteById(Guid userId)
        {
            User user = await UsersRepository.GetById(userId);
            await UsersRepository.DeleteById(userId);
            return true;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await UsersRepository.GetUsers();
        }

        public async Task<User> UpdateUserStatus(Guid id, bool newStatus)
        {
            User user = await UsersRepository.GetById(id);
            user.Active = newStatus;
            await UsersRepository.Update(user);
            return user;

        }
    }
}
