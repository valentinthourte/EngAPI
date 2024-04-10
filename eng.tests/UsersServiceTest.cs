using eng.application.Model;
using eng.application.Services;
using eng.application.Services.Interface;
using eng.repository.Interface;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestClass]
    public class UsersServiceTest
    {
        private IUsersService usersService;
        private Mock<IUsersRepository> usersRepository;

        public UsersServiceTest()
        {
            this.usersRepository = new Mock<IUsersRepository>();
            this.usersService = new UsersService(this.usersRepository.Object);
        }

        [TestMethod]
        public async Task GetAllUsers_Correct()
        {
            // Arrange
            User user = new User(Guid.NewGuid(), "ValentinThourte", DateTime.Now);
            var users = new List<User>() { user };
            usersRepository.Setup(x => x.GetUsers()).ReturnsAsync(users);

            // Act
            List<User> serviceUsers = (await usersService.GetUsers()).ToList();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, serviceUsers.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(user, serviceUsers.First());
        }
    }
}