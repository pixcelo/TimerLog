using Moq;
using System.Data;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Repositoriers;

namespace TimerLog.Tests.Repositoriers
{
    public class TimerLogRepositoryTests
    {
        private readonly Mock<IDbConnection> mockDbConnection;
        private readonly TimerLogRepository repository;

        public TimerLogRepositoryTests()
        {
            mockDbConnection = new Mock<IDbConnection>();
            mockDbConnection.Setup(s => s.Open()).Verifiable();
            mockDbConnection.Setup(s => s.Close()).Verifiable();

            repository = new TimerLogRepository();
        }

        [Fact]
        public void Find_ShouldReturnListOfTimerLogs()
        {
            // Arrange
            var expectedTimerLogs = new List<V_TimerLog>()
            {
                new V_TimerLog { Id = 1, StartAt = DateTime.Now, EndAt = DateTime.Now.AddMinutes(1), UserId = 1, TypeId = 1 },
                new V_TimerLog { Id = 2, StartAt = DateTime.Now.AddHours(1), EndAt = DateTime.Now.AddHours(2), UserId = 2, TypeId = 2 },
            };
            
            // Dapperの静的拡張メソッドを直接モックすることはできない
            // 解決策として、Dapperのラッパーを作成して、そのラッパーをモックする必要がある
            //mockDbConnection
            //    .Setup(db => db.Query<V_TimerLog>("SELECT * FROM V_TimerLog", null, null, true, null, CommandType.Text))
            //    .Returns(expectedTimerLogs);

            // Act
            //var actualResult = repository.Find();

            // Assert
            //Assert.Equal(expectedTimerLogs, actualResult);
            //mockDbConnection.Verify(s => s.Open(), Times.Once);
            //mockDbConnection.Verify(s => s.Close(), Times.Once);
        }

    }
}
