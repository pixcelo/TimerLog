using TimerLog.WebAPI.Attributes;
using TimerLog.WebAPI.Models;

namespace TimerLog.Tests.Attributes
{
    /// <summary>
    /// <see cref="AttributeHelper"/>の単体テスト
    /// </summary>
    public class AttributeHelperTests
    {
        [Fact]
        public void OkHasMasterAttribute()
        {
            // Arrange
            var type = typeof(M_Users);

            // Act
            var actual = AttributeHelper.HasMasterAttribute(type);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void NgHasMasterAttribute()
        {
            // Arrange
            var type = typeof(T_TimerLog);

            // Act
            var actual = AttributeHelper.HasMasterAttribute(type);

            // Assert
            Assert.False(actual);
        }

    }
}
