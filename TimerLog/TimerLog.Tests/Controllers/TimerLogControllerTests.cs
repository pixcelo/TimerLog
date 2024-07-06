using Moq;
using TimerLog.WebAPI.Controllers;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Services;

namespace TimerLog.Tests.Controllers
{
    public class TimerLogControllerTests
    {
        private readonly Mock<ITimerLogService> mockTimerLogService;
        private readonly TimerLogController controller;

        public TimerLogControllerTests()
        {
            this.mockTimerLogService = new Mock<ITimerLogService>();
            this.controller = new TimerLogController(this.mockTimerLogService.Object);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkGet()
        {
            // Arrange
            var expected = new List<V_TimerLog>();
            this.mockTimerLogService.Setup(x => x.Find()).Returns(expected);

            // Act
            var actual = this.controller.Get();

            // Assert
            Assert.Same(expected, actual);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkPost()
        {
            // Arrange
            var expected = 1;
            var timerLog = new T_TimerLog();
            this.mockTimerLogService.Setup(x => x.Insert(timerLog)).Returns(expected);

            // Act
            var actual = this.controller.Post(timerLog);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkPut()
        {
            // Arrange
            var expected = 1;
            var timerLog = new T_TimerLog();
            this.mockTimerLogService.Setup(x => x.Update(timerLog)).Returns(expected);

            // Act
            var actual = this.controller.Put(timerLog);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// 正常系
        /// </summary>
        [Fact]
        public void OkDelete()
        {
            // Arrange
            var expected = 1;
            var id = 1;
            this.mockTimerLogService.Setup(x => x.Delete(id)).Returns(expected);

            // Act
            var actual = this.controller.Delete(id);

            // Assert
            Assert.Equal(expected, actual);
        }
        
    }
}
