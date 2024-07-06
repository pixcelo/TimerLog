using TimerLog.WebAPI.DB.SQLServer;

namespace TimerLog.Tests.DB.SQLServer
{
    /// <summary>
    /// <see cref="SQLServerHelper"/>の単体テスト
    /// </summary>
    public class SQLServerHelperTests
    {
        [Fact]
        public void GetConnectionString_ReturnsExpectedFormat()
        {
            // Arrange
            var server = "localhost";
            var database = "TestDB";
            var user = "testUser";
            var password = "testPassword";

            // Act
            var actual = SQLServerHelper.GetConnectionString(server, database, user, password);

            // Assert
            var expected = $"Data Source={server};Initial Catalog={database};User ID={user};Password={password}";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetConnectionStringWithWindowsAuth_ReturnsExpectedFormat()
        {
            // Arrange
            var server = "localhost";
            var database = "TestDB";

            // Act
            var actual = SQLServerHelper.GetConnectionStringWithWindowsAuth(server, database);

            // Assert
            var expected = $"Data Source={server};Initial Catalog={database};Integrated Security=True";
            Assert.Equal(expected, actual);
        }
    }
}
