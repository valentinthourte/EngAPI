using eng.application.Model;
using eng.repository.Interface;
using NHibernate.Engine.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eng.repository
{
    public class UsersRepository : IUsersRepository
    {
        private IRepository Repository;
        public UsersRepository(IRepository _repository)
        {
            Repository = _repository;
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                Repository.BeginTransaction();
                user.Id = await Repository.Save(user);
                Repository.CommitTransaction();
                return user;
            }
            catch
            {
                Repository.RollbackTransaction();
                throw;
            }
        }

        public async Task<bool> DeleteById(Guid userId)
        {
            await Task.Run(() => Repository.DeleteAsync(userId));
            return true;
        }

        public async Task<User> GetById(Guid userId)
        {
            return (await Repository.GetById(typeof(User), userId) as User);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.Run(() => (Repository.ToList<User>()).ToList());
        }

        public async Task Update(User user)
        {
            await Repository.MergeAsync(user);
        }
    }
}
