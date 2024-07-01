using Microsoft.AspNetCore.Mvc;
using TimerLog.WebAPI.Models;
using TimerLog.WebAPI.Services;

namespace TimerLog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerLogController : ControllerBase
    {
        private readonly ITimerLogService timerLogService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="timerLogService"></param>
        public TimerLogController(ITimerLogService timerLogService)
        {
            this.timerLogService = timerLogService;
        }

        [HttpGet]
        public List<V_TimerLog> Get()
        {
            return this.timerLogService.Find();
        }

        [HttpPost]
        public int Post([FromBody] T_TimerLog timerLog)
        {
            return this.timerLogService.Insert(timerLog);
        }

        [HttpPut]
        public int Put([FromBody] T_TimerLog timerLog)
        {
            return this.timerLogService.Update(timerLog);
        }

        [HttpDelete("{id}")]
        public int Delete(long id)
        {            
            return this.timerLogService.Delete(id);
        }

    }
}
