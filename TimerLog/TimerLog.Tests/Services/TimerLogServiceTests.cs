using Moq;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Repositoriers;
using TimerLog.WebAPI.Services;

namespace TimerLog.Tests.Services
{
    public class TimerLogServiceTests
    {
        private readonly Mock<IUsersRepository> mockUsersRepository;
        private readonly UsersService service;

        public TimerLogServiceTests()
        {
            this.mockUsersRepository = new Mock<IUsersRepository>();
            this.service = new UsersService(this.mockUsersRepository.Object);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkGet()
        {
            // Arrange
            var expectedUsers = new List<M_Users>()
            {
                new M_Users { Id = 1, Name = "Tom" },
                new M_Users { Id = 2, Name = "Ken" },
            };

            mockUsersRepository.Setup(s => s.Get()).Returns(expectedUsers);

            // Act
            var actualResult = service.Get();

            // Assert
            Assert.Equal(expectedUsers, actualResult);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkInsert()
        {
            // Arrange
            var newUser = new M_Users { Name = "Mary" };
            var expectedId = 10;

            mockUsersRepository.Setup(s => s.Insert(newUser)).Returns(expectedId);

            // Act
            var actualResult = service.Insert(newUser);

            // Assert
            Assert.Equal(expectedId, actualResult);
            mockUsersRepository.Verify(s => s.Insert(newUser), Times.Once);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkUpdate()
        {
            // Arrange
            var existingUser = new M_Users { Id = 5, Name = "更新対象ユーザー" };

            mockUsersRepository.Setup(s => s.Update(existingUser)).Returns(1);

            // Act
            var actualResult = service.Update(existingUser);

            // Assert
            Assert.Equal(1, actualResult);
            mockUsersRepository.Verify(s => s.Update(existingUser), Times.Once);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void Delete_ShouldCallUserRepositoryAndReturnSuccess()
        {
            // Arrange
            var targetId = 123;

            mockUsersRepository.Setup(s => s.Delete(targetId)).Returns(1);

            // Act
            var actualResult = service.Delete(targetId);

            // Assert
            Assert.Equal(1, actualResult);
            mockUsersRepository.Verify(s => s.Delete(targetId), Times.Once);
        }

    }
}
