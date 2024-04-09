using eng.application.Model;

namespace eng.repository.Interface
{
    public interface IUsersRepository
    {
        Task<User> CreateUser(User user);
        Task<bool> DeleteById(Guid userId);
        Task<User> GetById(Guid userId);
        Task<IEnumerable<User>> GetUsers();
        Task Update(User user);
    }
}
