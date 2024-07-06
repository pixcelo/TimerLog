using Moq;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Repositoriers;
using TimerLog.WebAPI.Services;

namespace TimerLog.Tests.Services
{
    public class UsersServiceTests
    {
        private readonly Mock<IUsersRepository> mockUsersRepository;
        private readonly UsersService service;

        public UsersServiceTests()
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
            var expected = new List<M_Users>()
            {
                new M_Users { Id = 1, Name = "Tom" },
                new M_Users { Id = 2, Name = "Ken" },
            };

            mockUsersRepository.Setup(s => s.Get()).Returns(expected);

            // Act
            var actual = service.Get();

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkInsert()
        {
            // Arrange
            var newUser = new M_Users { Name = "Mary" };
            var expected = 10;

            mockUsersRepository.Setup(s => s.Insert(newUser)).Returns(expected);

            // Act
            var actual = service.Insert(newUser);

            // Assert
            Assert.Equal(expected, actual);
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
            var actual = service.Update(existingUser);

            // Assert
            Assert.Equal(1, actual);
            mockUsersRepository.Verify(s => s.Update(existingUser), Times.Once);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkDelete()
        {
            // Arrange
            var targetId = 123;

            mockUsersRepository.Setup(s => s.Delete(targetId)).Returns(1);

            // Act
            var actual = service.Delete(targetId);

            // Assert
            Assert.Equal(1, actual);
            mockUsersRepository.Verify(s => s.Delete(targetId), Times.Once);
        }

        /// <summary>
        /// 正常系_例外を発生させるテスト
        /// </summary>
        [Fact]
        public void OkThrowException()
        {
            // Arrange
            var mockUsersRepository = new Mock<IUsersRepository>();

            mockUsersRepository
                .Setup(s => s.Get())
                .Throws(new InvalidOperationException("connection error"));

            // Act
            var service = new UsersService(mockUsersRepository.Object);

            // Assert
            Assert.Throws<InvalidOperationException>(() => service.Get());
        }

    }
}
